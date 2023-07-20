using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FavListUserManagement.Application.IServices
{
    public interface IQuestionService
    {
        Task<Response<string>> Create(QuestionDto question);
        Task<Response<ICollection<QuestionResponseDto>>> GetQuestion(string? categoryId);
        Task<Response<string>> Update(string questionId, UpdateQuestionDto question);
        Task<string> UpLoadExcel(IFormFile formFile);
        // Task<Response<string>> QuestionSearch(string search);
        Task<Response<List<QuestionSearchDto>>> QuestionSearch(string search);
        Task<Response<ICollection<QuestionResponseDto>>> GetAllQuestion();
        Task<Response<string>> DeleteQuestion(string questionId);
    }
}
