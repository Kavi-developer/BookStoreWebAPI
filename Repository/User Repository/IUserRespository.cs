using BooksStoreWebAPI.DTO_s;
using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.User_Repository
{
    public interface IUserRespository
    {
        Task<List<User>> GetAllUsers();

        Task<User?> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(int UserId,User user);

        Task<User> DeleteUser(int userId);
        string GenerateToken(UserLoginDTO loginDTO);

    }
}
