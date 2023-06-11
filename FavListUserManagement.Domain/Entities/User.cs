using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class User : IdentityUser 
    {
        //public virtual Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Created_Date { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Deleted { get; set; } = false;
        //public UserRole? Roles_id { get; set; }
        public DateTime Last_Modified { get; set; }
        public string Refreshtoken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
