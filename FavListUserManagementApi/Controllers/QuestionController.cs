using AutoMapper;
using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.Repository;
using FavListUserManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavListUserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IUnitOfWork _unityOfWork;
        private readonly IQuestionService _service;

        public QuestionController(IUnitOfWork unityOfWork,IQuestionService service)
        {
            _unityOfWork = unityOfWork;
            _service = service;
        }

        [HttpPost]
        [Route("create-question")]
        public async Task<IActionResult> Create(QuestionDto question)
        {
            try
            {
                
                var result = await _service.Create(question);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get-question-by-category")]
        public async Task<IActionResult> GetQuestion(string? category)
        {
            try
            {
               var result = await _service.GetQuestion(category);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get-all-questions")]
        public async Task<IActionResult> GetAllQuestion()
        {
            try
            {
                var reslut = _service.GetAllQuestion();
                return Ok(reslut);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update-question")]
        public async Task<IActionResult> Update(string questionId, UpdateQuestionDto question)
        {
            try
            {

                var result = await _service.Update(questionId,question);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("upload-excel-file")]
        public async Task<IActionResult> UploadExcelFile(IFormFile formFile)
        {
            try
            {
                var result = await _service.UpLoadExcel(formFile);
                return Ok(result); 
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> QuestionSearch(string search)
        {
            try
            {
                var result = await _service.QuestionSearch(search);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-question")]
        public async Task<IActionResult> Delete(string questionId)
        {
            try
            {
                var del = await _service.DeleteQuestion(questionId);
                return Ok(del);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
