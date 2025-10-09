using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
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
        public enum Role;
        public string? Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        // public User CreatedBy{ get; set; }
    }   
}