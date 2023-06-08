using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class SignUp : BaseEntity
    {
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
        //public string? UserName { get; set; }
    }
}
