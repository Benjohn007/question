using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.IServices
{
    public interface IQuestionDraftService
    {
        Task<Response<string>> SaveAsQuestion(ICollection<string> question);
        Task<Response<string>> UpdateQuestionDraft(string draftId, QuestionDraftDto question);
        Task<Response<string>> CreateQuestionDraft(QuestionDraftDto question);
    }
}
