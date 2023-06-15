using System.Runtime.InteropServices;

namespace FavListUserManagement.Domain.Entities
{
    public class Catergory : BaseEntity
    {  
        public string? Name { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
    }
}