using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Pharmacie_management.Models
{
    public class User
    {
        public User()
        {
            
        }
        public User(int id)
        {
            UserId = id;
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}