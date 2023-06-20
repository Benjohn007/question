using AutoMapper;
using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.DbContext;
using FavListUserManagement.Infrastructure.Repository;
using FavListUserManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _catergory;
        private readonly ApplicationDbContext context;
        private readonly IAnswerRepository _answerRepository;

        public QuestionService(IQuestionRepository questionRepository,IMapper mapper,
            IUnitOfWork unitOfWork,ICategoryRepository catergory, ApplicationDbContext context, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _catergory = catergory;
            this.context = context;
            _answerRepository = answerRepository;
        }

        public async Task<Response<string>> Create(QuestionDto question)
        {
            var response = new Response<string>();
            

            if (question != null)
            {
                var mapp = _mapper.Map<Question>(question);
                mapp.Id = Guid.NewGuid().ToString();

                var answers = new List<Answer>();
                question.Answer?.ForEach(x =>
                {
                    answers.Add(new Answer
                    {
                        Text = x
                    });
                });
                mapp.Answer = answers;

                await _questionRepository.AddAsync(mapp);
                 
                response.Succeeded = true;
                response.StatusCode = (int)HttpStatusCode.Created;
                response.Message = "Successfully registered";
                response.Data = "";

                await _unitOfWork.SaveChanges();

                return response;
            }

            response.Succeeded = false;
            response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            response.Message = "Failed to register, please change check the email, username and password.";
            return response;
            
        }

        
        public async Task<Response<ICollection<QuestionResponseDto>>> GetQuestion(string? categoryId)
        {
            
            try
            {
                var questions = await _questionRepository.GetAllAsync(x => string.IsNullOrEmpty(categoryId) 
                ? !string.IsNullOrEmpty(x.CatergoryId) : x.CatergoryId == categoryId);
                var mapp = _mapper.Map<ICollection<QuestionResponseDto>>(questions);

                //var result = await _questionRepository.GetByIdAsync(x => x.Id == Id);
                return Response<ICollection<QuestionResponseDto>>.Success("", mapp, 200);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<string>> Update(string questionId, UpdateQuestionDto question)
        {
            var response = new Response<string>();


            if (questionId != null)
            {
                var result = await _questionRepository.GetByIdAsync(x => x.Id == questionId);

                if(result != null)
                {
                    if (!string.IsNullOrEmpty(question.Text?.Trim()))
                    {
                        _mapper.Map(question, result);
                    }
                     
                    if (question.Answer != null && question.Answer.Any())
                    {
                        foreach(var answer in question.Answer)
                        {
                            if (!string.IsNullOrEmpty(answer.Id))
                            {
                                var answerFromDb = await _answerRepository.GetByIdAsync(y => y.Id == answer.Id);
                                if (answerFromDb != null)
                                {
                                    answerFromDb.Text = answer.Text ?? answerFromDb.Text;
                                    answerFromDb.Weight = answer.Weight ?? answerFromDb.Weight;
                                }   
                            }
                            else
                            {
                                //create a new answer and add to question
                                var newAnswer = new Answer
                                {
                                    Text = answer.Text,
                                    QuestionId = result.Id,
                                    Weight = answer.Weight ?? 0
                                };

                                await _answerRepository.AddAsync(newAnswer);
                            }
                        }
                    }

                    //await _questionRepository.UpdateAsync(result,question);

                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Created;
                    response.Message = "Successfully registered";
                    response.Data = "";

                    await _unitOfWork.SaveChanges();

                    return response;

                }

                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = "Failed to register, please change check the email, username and password.";
                return response;
            }

            response.Succeeded = false;
            response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            response.Message = "Failed to register, please change check the email, username and password.";
            return response;

        }

    }
}
