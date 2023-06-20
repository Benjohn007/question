using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.DTO
{
    public class CategoryDto
    {
        public String? Name { get; set; }
       // public ICollection<Question>? Question { get; set; }

    }

    public class UpdateCategoryDto
    {
        public String? Name { get; set; }
        public ICollection<QuestionRequestDto>? Question { get; set; }

    }

    public class QuestionRequestDto
    {
        public string? Id { get; set; }
        public string? Text { get; set; }
    }
}
