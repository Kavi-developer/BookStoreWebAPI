using Microsoft.AspNetCore.Authorization;

namespace BooksStoreWebAPI.Services
{
    public class CustomRequirement : IAuthorizationRequirement
    {
        public string role;

        public string[] requiredRole { get; set; }

        public CustomRequirement()
        {
            
        }
        public CustomRequirement(string role)
        {
            this.role = role;
        }

        public CustomRequirement(string[] requiredRole)
        {
            this.requiredRole = requiredRole;
        }
    }
}
