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
    public class CatergoryService : ICatergoryService
    {
        private readonly ICategoryRepository _catergoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;

        public CatergoryService(ICategoryRepository catergoryRepository,IUnitOfWork unitOfWork, IMapper mapper,IQuestionRepository questionRepository)
        {
            _catergoryRepository = catergoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        public async Task<Response<string>> Create(CategoryDto catergory)
        {
            try
            {
                var response = new Response<string>();

                if (catergory != null)
                {
                    var mapp = _mapper.Map<Category>(catergory);

                    await _catergoryRepository.AddAsync(mapp);

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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public async Task<Response<List<CategoryDto>>> GetAll()
        {
            try
            {
                 var response = new Response<List<CategoryDto>>();
                IEnumerable<Category> cat = await _catergoryRepository.GetAllAsync(x => !x.Is_Deleted);
               

                var result = _mapper.Map<List<CategoryDto>>(cat);
                if(cat != null)
                {
                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Found;
                    response.Data = result;

                    return response;
                }
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = "categories can not be found";
                return response;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<string>> GetById(string categoryId)
        {
            try
            {
                var response = new Response<string>();
                var cat = await _catergoryRepository.GetByIdAsync(x => x.Id == categoryId);
                if( cat != null && !cat.Is_Deleted)
                {
                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Found;
                    response.Data = cat.Name;

                    return response;
                }
                if(cat!=null && cat.Is_Deleted)
                {
                    response.Succeeded = false;
                    response.StatusCode = (int)HttpStatusCode.Found;
                    response.Message = "this category is deleted";
                    response.Data = cat.Name;

                    return response;
                }
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = "category can not be found";
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<string>> DeleteCategory(string categoryId)
        {
            try
            {
                var response = new Response<string>();
                var cat = await _catergoryRepository.GetByIdAsync(x => x.Id == categoryId);

                if (cat != null)
                {
                   cat.Is_Deleted = true;
                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.NoContent;
                    response.Message = "Successfully deleted";
                    await _unitOfWork.SaveChanges();
                    return response;
                }
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = "failed. user not found";
                return response;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<string>> UpdateCategory(string categoryId, UpdateCategoryDto categoryDto)
        {
            var response = new Response<string>();


            //if (categoryId != null)
            //{
            //    var result = await _catergoryRepository.GetByIdAsync(x => x.Id == categoryId);
            //    var update = await _catergoryRepository.UpdateAsync(result, categoryDto);
            //}

            if (categoryId != null)
            {
                var result = await _catergoryRepository.GetByIdAsync(x => x.Id == categoryId);

                if (result != null)
                {
                    if (!string.IsNullOrEmpty(categoryDto.Name?.Trim()))
                    {
                        _mapper.Map(categoryDto, result);
                    }

                    if (categoryDto.Question != null && categoryDto.Question.Any())
                    {
                        foreach (var question in categoryDto.Question)
                        {
                            if (!string.IsNullOrEmpty(question.Id))
                            {
                                var questionFromDb = await _catergoryRepository.GetByIdAsync(y => y.Id == question.Id);
                                if (questionFromDb != null)
                                {
                                    questionFromDb.Name = question.Text ?? questionFromDb.Name;
                                    //answerFromDb.Weight = answer.Weight ?? answerFromDb.Weight;
                                }
                            }
                            else
                            {
                                //create a new answer and add to question
                                var newAnswer = new Question
                                {
                                    Text = question.Text,
                                    CatergoryId = result.Id,
                                };

                                await _questionRepository.AddAsync(newAnswer);
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

            }
            response.Succeeded = false;
            response.StatusCode = (int)HttpStatusCode.NotFound;
            response.Message = "Failed to register, please change check the email, username and password.";
            return response;

        }
    }
}
