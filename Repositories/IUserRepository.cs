using Pharmacie_management.Models;

namespace Pharmacie_management.Repositories
{
    public interface IUserRepository
    {
        /*Initially I used primitive type but then used Task 
        to use asynchronous function because I am using the db*/
        void AddUser(User user);
        Task<User> GetUserByName(string name);

        Task<bool> IsLoginValid(string name, string password);
    }
}