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
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
        public string? UserName { get; set; }
        public string? Gender { get; set; }

        public int Age { get; set; }
    }
}
