using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class QuestionDefaultParameter : BaseEntity
    {
        public int Days_to_remain_open { get; set; }
        public int Min_answer_count { get; set; }
        public int Max_answer_count { get; set; }
      
    }
}
