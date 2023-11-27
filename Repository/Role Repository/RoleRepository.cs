using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Repository.Role_Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BookDbContext context;

        public RoleRepository(BookDbContext context)
        {
            this.context = context;
        }
        public async Task<Role> AddRole(Role role)
        {
            try
            {
                if (role == null)
                {
                    return null;
                }
                await context.Roles.AddAsync(role);
                await context.SaveChangesAsync();
                return role;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Role> DeleteRole(int roleId)
        {
            try
            {
                var role = await context.Roles.FirstOrDefaultAsync(a => a.RoleId == roleId);
                if (role == null)
                {
                    return null;
                }
                context.Roles.Remove(role);
                await context.SaveChangesAsync();
                return role;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<List<Role>> GetAllRoles()
        {
            return context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleById(int roleId)
        {
            try
            {
                var role = await context.Roles.FirstOrDefaultAsync(a => a.RoleId == roleId);
                if (role == null)
                {
                    return null;
                }
                return role;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Role> UpdateRole(int roleId, Role role)
        {
            try
            {
                var resRole = await context.Roles.FirstOrDefaultAsync(a => a.RoleId == roleId);
                if (resRole == null)
                {
                    return null;
                }
                resRole.RoleName = role.RoleName;
               
                resRole.RoleRights = role.RoleRights;

                await context.SaveChangesAsync();
                return resRole;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    
}
