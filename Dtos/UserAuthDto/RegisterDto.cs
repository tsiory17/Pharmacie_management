using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Pharmacie_management.Dtos.UserAuthDto
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="Name cannot be empty")]
        public string Name { get; set; }

        [Required]
        [MinLength(4,ErrorMessage ="The password needs to be at least 4 characters")]
        public string Password { get; set; }
    }
}