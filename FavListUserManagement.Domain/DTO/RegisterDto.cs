using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavListUserManagement.Domain.Entities;

namespace FavListUserManagement.Domain.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Firstname { get; set; } =string.Empty;
        [Required]
        public string? Lastname { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}
