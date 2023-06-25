using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.DTO
{
    public class QuestionDto
    {
        public string? UserId { get; set; }
        public string? Text { get; set; }
        public string? SponsorId { get; set; }
        public string? CatergoryId { get; set; }
        public List<string>? Answer { get; set; } = new List<string>();
    }

    public class QuestionDraftDto
    {
        public string? Text { get; set; }
        public List<string>? Answer { get; set; }
        public string CategoryId { get; set; }
    }
}
