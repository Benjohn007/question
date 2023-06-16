using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class ResetPassword
    {
        [Required]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The Password and ConfirmPassword does not match")]
        public string? ConfirmPassword { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
