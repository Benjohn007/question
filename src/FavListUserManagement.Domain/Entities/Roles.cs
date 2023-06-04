using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class Roles
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Is_Admin { get; set; }
        public Guid Create_by_id { get; set; }
        public DateTime Create_date { get; set; }
    }
}
