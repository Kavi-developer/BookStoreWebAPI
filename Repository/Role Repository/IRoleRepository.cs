using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.Role_Repository
{
    public interface IRoleRepository 
    {
        Task<List<Role>> GetAllRoles();
        Task<Role?> GetRoleById(int roleId);

        Task<Role> AddRole(Role role);

        Task<Role> UpdateRole(int roleId,Role role);

        Task<Role> DeleteRole(int roleId);

    }
}
