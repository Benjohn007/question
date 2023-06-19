using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.DTO
{
    public class QuestionResponseDto
    {
        public string? CatergoryId { get; set; }
        public string? Text { get; set; }
        public ICollection<Answer>? Answer { get; set; }
        public DateTime Data_To_Post { get; set; }
        public string? SponsorId { get; set; }
        public string? UserId { get; set; }


    }
}
