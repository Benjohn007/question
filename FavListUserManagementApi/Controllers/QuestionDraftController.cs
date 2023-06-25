using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavListUserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionDraftController : ControllerBase
    {
        private readonly IQuestionDraftService _questionDraftService;

        public QuestionDraftController(IQuestionDraftService questionDraftService)
        {
            _questionDraftService = questionDraftService;
        }

        [HttpPost]
        [Route("create-question-as-draft")]
        public async Task<IActionResult> Create(QuestionDraftDto question)
        {
            try
            {
                if (question == null)
                    return BadRequest("questions can not be null");

                var result = await _questionDraftService.CreateQuestionDraft(question);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-drafted-question")]
        public async Task<IActionResult> UpdateDraft(string draftId, QuestionDraftDto question)
        {
            try
            {
                if (string.IsNullOrEmpty(draftId) || question == null)
                    return BadRequest("Id or draft question can not be null");
                var result = await _questionDraftService.UpdateQuestionDraft(draftId, question);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("save-draft-to-question")]
        public async Task<IActionResult> SaveAsQuestion(ICollection<string> question)
        {
            try
            {
                var result = await _questionDraftService.SaveAsQuestion(question);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
