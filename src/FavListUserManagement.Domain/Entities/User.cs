using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Creat_date { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Deleted { get; set; } = false;
        public Roles? Roles_id { get; set; }
    }
}
