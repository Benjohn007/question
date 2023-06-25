using AutoMapper;
using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
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
    public class QuestionDraftServive : IQuestionDraftService
    {
        private readonly IQuestionDraftRepository _questionDraftRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuestionRepository _questionRepository;

        public QuestionDraftServive(IQuestionDraftRepository questionDraftRepository, IMapper mapper,
            IUnitOfWork unitOfWork,ICategoryRepository categoryRepository,IQuestionRepository questionRepository)
        {
            _questionDraftRepository = questionDraftRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _questionRepository = questionRepository;
        }
        public async Task<Response<string>> CreateQuestionDraft(QuestionDraftDto question)
        {
            try
            {
                var response = new Response<string>();


                if (question != null)
                {
                    var mapp = new QuestionDraft
                    {
                        Text = question.Text,
                        Answer = question.Answer != null ? string.Join(',', question.Answer) : string.Empty
                    };

                    await _questionDraftRepository.AddAsync(mapp);

                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Created;
                    response.Message = "Saved to Draft";
                    response.Data = "";

                    await _unitOfWork.SaveChanges();

                    return response;
                }

                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                response.Message = "Failed to created.";
                return response;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public async Task<Response<string>> UpdateQuestionDraft(string draftId, QuestionDraftDto question)
        {
            try
            {
                var response = new Response<string>();


                if (draftId != null)
                {
                    var result = await _questionDraftRepository.GetByIdAsync(x => x.Id == draftId);

                    if (result != null)
                    {
                        if (!string.IsNullOrEmpty(question.Text?.Trim()))
                        {
                            result.Text = question.Text;
                        }
                        result.Answer = question.Answer != null ? string.Join(',', question.Answer) : string.Empty;

                        response.Succeeded = true;
                        response.StatusCode = (int)HttpStatusCode.Created;
                        response.Message = "Successfully updated";
                        response.Data = "";

                        await _unitOfWork.SaveChanges();

                        return response;

                    }

                    response.Succeeded = false;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Failed to update.";
                    return response;
                }

                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                response.Message = "Failed to update.";
                return response;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Response<string>> SaveAsQuestion(ICollection<string> question)
        {
            try
            {
                var response = new Response<string>();

                var questionDraft = await _questionDraftRepository.GetAllAsync(x => question.Contains(x.Id) && !x.Is_Active);

                var questions = new List<Question>();

                foreach (var item in questionDraft)
                {
                    if (string.IsNullOrEmpty(item.Id))
                    {
                        //return error category can not be null
                        response.Succeeded = false;
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        response.Message = "category can not be null";
                        return response;
                    }
                    var answersText = item.Answer?.Split(',').ToList();
                    var answers = new List<Answer>();
                    answersText?.ForEach(x =>
                    {
                        answers.Add(new Answer
                        {
                            Text = x
                        });
                    });
                    var quest = new Question
                    {
                        Text = item.Text,
                        Answer = answers,
                        CatergoryId = item.CategoryId
                    };
                    questions.Add(quest);
                }

                await _questionRepository.AddRangeAsync(questions);

                response.Succeeded = true;
                response.StatusCode = (int)HttpStatusCode.Created;
                response.Message = "Successfully created";
                response.Data = "";

                await _unitOfWork.SaveChanges();
                return response;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }


    }
}
