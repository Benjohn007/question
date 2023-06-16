using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string? Text { get; set; }
        public int Vote_Count { get; set; }
        public int Weight { get; set; }
    }
}
