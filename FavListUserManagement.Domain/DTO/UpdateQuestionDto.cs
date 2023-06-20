using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.DTO
{
    public class UpdateQuestionDto
    {
        public string? Text { get; set; }
        public ICollection<AnswerRequestDto>? Answer { get; set; }

    }

    public class AnswerRequestDto
    {
        public string? Id { get; set; }
        public string? Text { get; set; }
        public int? Weight { get; set; }
    }
}
