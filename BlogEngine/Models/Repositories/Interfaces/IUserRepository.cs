using BlogEngine.Models.Entities;

namespace BlogEngine.Models.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByID(int userID);
    }
}