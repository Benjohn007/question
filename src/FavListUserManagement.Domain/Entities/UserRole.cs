using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    //public class UserRole : BaseEntity
    //{
    //    public string RoleName { get; set; } = string.Empty;
    //    public string Description { get; set; } = string.Empty;
    //    public bool Is_Admin { get; set; }
    //    public Roles Roles { get; set; }
    //}

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRole
    {
        SuperAdmin,
        Admin,
        AppUser
    }
}
