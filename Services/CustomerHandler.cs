using BooksStoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BooksStoreWebAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;

namespace BooksStoreWebAPI.Services
{
    public class CustomerHandler : AuthorizationHandler<CustomRequirement>
    {
        private readonly BookDbContext dbcontext;
        private readonly IHttpContextAccessor contextAccessor;

        public CustomerHandler(BookDbContext dbcontext,IHttpContextAccessor contextAccessor)
        {
            this.dbcontext = dbcontext;
            this.contextAccessor = contextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            CustomRequirement requirement)
        {
            try
            {
                var roleId = contextAccessor.HttpContext.User.FindFirst("RoleId").Value;

                var role = dbcontext.Roles.FirstOrDefault(a => a.RoleId.ToString() == roleId);

                if (requirement.requiredRole != null)
                {
                    if (requirement.requiredRole.Any(a => a.Contains(role.RoleName)))
                    {
                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
                }
                else
                {
                    if (role.RoleName == requirement.role)
                    {
                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
                }

                return Task.CompletedTask;
            }catch (Exception ex) {
                return Task.FromException(ex.InnerException);
            }
        }
    }
}
    