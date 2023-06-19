using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string? Text { get; set; }
        public DateTime Data_To_Post { get; set; } = DateTime.Now;
        public string? SponsorId { get; set; }
        public DateTime Days_To_Remain_Open { get; set; } = new DateTime();
        public int Min_Answer_Count { get; set; }   
        public int Max_Answer_Count { get; set; }
       // public Answer? Answer { get; set; }
        public bool MigratedToRedis { get; set; } = false;
        public User? User { get; set; }
        public string? UserId { get; set; }

        public string? CatergoryId { get; set; }

        public Category? Catergory { get; set; }

        public Sponsor? Sponsor { get; set; }

        public ICollection<Answer>? Answer { get; set; }

    }
}
