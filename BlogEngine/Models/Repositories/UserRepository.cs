using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories.Interfaces;

namespace BlogEngine.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByID(int userID)
        {
            return new User
            {
                Name = "Fred"
            };
        }
    }
}