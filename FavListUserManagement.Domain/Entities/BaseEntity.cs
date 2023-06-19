using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string? Id { get; set; }
        public string Created_By_Id { get; set; } = string.Empty;
        public string Modified_By { get; set; } = string.Empty;
        public virtual DateTime Created_Date { get; set; } = DateTime.Now;
        public DateTime Last_Modified { get; set; }
        public bool Is_Deleted { get; set; } = false;
        public bool Is_Active { get; set; }
        public DateTime Last_update_date { get; set; }
        public Guid Update_by_id { get; set; }
    }
}
