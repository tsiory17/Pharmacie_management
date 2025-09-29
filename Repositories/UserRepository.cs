using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Pharmacie_management.Data;
using Pharmacie_management.Models;

namespace Pharmacie_management.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

      
        public async Task<User> GetUserByName(string name)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync<User>(u => u.Name == name);
        }

        public async Task<bool> IsLoginValid(string name, string password)
        {
            //if userName == name and if userPassword == password then return True 
            var userToLogin = await GetUserByName(name);

            if (userToLogin == null) { return false; }

            // return userToLogin.Password == password;

            //using the bcrypt to verify the password hashed
            return BCrypt.Net.BCrypt.Verify(password, userToLogin.Password);
               
        }
    }
}