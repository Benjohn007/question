using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class Question : BaseEntity
    {
       public string? text { get; set; }
       public Sponsor? sponsor { get; set; }
       public string? SponsorId { get; set; }
       public DateTime days_to_remain_open { get; set; }
       public DateTime date_to_post { get; set; }
       public int min_answer_count { get; set; }
       public int max_answer_count { get; set; }
       public User? User { get; set; }
       public string? UserId { get; set; }
        public List<string>? Answer { get; set; } 
       public Catergory? Catergory { get; set; }
       public string? CatergoryId { get; set; }
       public bool MigratedToRedis { get; set;} = false;
    }
}
