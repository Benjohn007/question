using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class QuestionDefaultParameter
    {
        public Guid Id { get; set; }
        public int Day_to_remain_open { get; set; }
        public int Min_answer_count { get; set; }
        public int Max_answer_count { get; set; }
        public Guid Create_by_id { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Last_update_date { get; set; }
        public Guid Update_by_id { get; set; }
    }
}
