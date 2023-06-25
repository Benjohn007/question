using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.DbContext;
using FavListUserManagement.Infrastructure.Migrations;
using FavListUserManagement.Infrastructure.Repository;
using FavListUserManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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

        public async Task<string> UpLoadExcel(IFormFile formFile)
        {
            string content;
            await using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                content = Convert.ToBase64String(memoryStream.ToArray());
            }

            List<QuestionUploadViewModel> records;
            try
            {
                
                using (var reader = new StreamReader(new MemoryStream(Convert.FromBase64String(content))))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.RegisterClassMap<QuestionUploadViewModelMap>();
                        csv.Configuration.MissingFieldFound = null;
                        csv.Configuration.BadDataFound = null;
                        csv.Configuration.TrimOptions = TrimOptions.Trim;
                        records = csv.GetRecords<QuestionUploadViewModel>().ToList();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (!records.Any())
            {
                //do nothing
                //return success;
            }

            var categoriesToAdd = new List<Category>();

            foreach (var item in records)
            {
                var isNewCategory = false;

                var category = await _catergory.GetByIdAsync(x => x.Name.ToLower().Trim() == item.Category.ToLower().Trim());
                if(category == null)
                {
                    category = new Category { Id = Guid.NewGuid().ToString(), Name = item.Category };
                    isNewCategory = true;
                }
                else
                {
                    category.Question = await _questionRepository.GetAllAsync(x => x.CatergoryId == category.Id);
                }
                var answersText = item.Answer?.Trim().Split(',').ToList();
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
                    CatergoryId = category.Id
                };
                if (category.Question != null)
                {
                    category.Question.Add(quest);
                }
                else
                {
                    category.Question = new List<Question>
                    {
                        quest
                    };
                }
                if (isNewCategory)
                {
                    categoriesToAdd.Add(category);
                }

            }
            if(categoriesToAdd.Any())
                await _catergory.AddRangeAsync(categoriesToAdd);

            await _unitOfWork.SaveChanges();
            return "";
        }


    }

    public class QuestionUploadViewModelMap : ClassMap<QuestionUploadViewModel>
    {
        public QuestionUploadViewModelMap()
        {
            Map(m => m.Text).Name("Text");
            Map(m => m.Category).Name("Category");
            Map(m => m.Sponsor).Name("Sponsor");
            Map(m => m.Answer).Name("Answer");
        }
    }

    public class QuestionUploadViewModel
    {
        [Order]
        [Name("Text")]
        public string Text { get; set; }

        [Order]
        [Name("Category")]
        public string Category { get; set; }

        [Order]
        [Name("Sponsor")]
        public string Sponsor { get; set; }

        [Order]
        [Name("Answer")]
        public string Answer { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute
    {
        private readonly int _order;
        public OrderAttribute([CallerLineNumber] int order = 0)
        {
            _order = order;
        }

        public int Order { get { return _order; } }
    }
}
