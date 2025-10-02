using System.ComponentModel.DataAnnotations;
namespace Pharmacie_management.Dtos.UserDto
{
    public class UpdateUserDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
       
        [MinLength(4)]
        public string? Password { get; set; }
    }
}