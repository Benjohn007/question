using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class QuestionDraft : BaseEntity
    {
        public string? Text { get; set; }
        public string? Answer { get; set; }

        public string? CategoryId {  get; set; }

    }
}
