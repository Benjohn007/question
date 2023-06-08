using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public bool Is_Admin { get; set; }
        public Roles Roles { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Roles
    {
        SuperAdmin = 0,
        Admin = 1,
        AppUser = 3,
    }
}
