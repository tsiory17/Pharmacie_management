using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Pharmacie_management.Dtos.UserAuthDto
{
    public class LoginDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}