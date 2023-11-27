using BooksStoreWebAPI.DTO_s;
using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BooksStoreWebAPI.Repository.User_Repository
{
    public class UserRepository : IUserRespository

    {
        private readonly BookDbContext context;
        private readonly IConfiguration configuration;

        public UserRepository(BookDbContext context,IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

       

        public async Task<User> AddUser(User user)
        {
            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return user;
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<User> DeleteUser(int userId)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(a => a.UserId == userId);
                if (user == null)
                {
                    return null;
                }
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return user;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GenerateToken(UserLoginDTO loginDTO)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, loginDTO.Email));

            var user = context.Users.FirstOrDefault(a => a.Email == loginDTO.Email);
            var role = context.Roles.FirstOrDefault(a => a.RoleId == user.RoleId);
            

            claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            claims.Add(new Claim("RoleId", role.RoleId.ToString()));

            var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

            var credentials= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
               configuration["JWT:Issuer"],
               configuration["JWT:Audience"],
               claims,
               expires:DateTime.Now.AddHours(1),
               signingCredentials: credentials
            );

                return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var users= await context.Users.ToListAsync();
                return users;
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<User?> GetUserById(int id)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(a => a.UserId == id);
                if (user == null)
                {
                    return null;
                }
                return user;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> UpdateUser(int userId,User user)
        {
            try
            {
                var resUser = await context.Users.FirstOrDefaultAsync(a => a.UserId == userId);
                if (resUser == null)
                {
                    return null;
                }
              resUser.UserName= user.UserName;
                resUser.Password=user.Password;
                resUser.Email=user.Email;
                resUser.RoleId = user.RoleId;

                await context.SaveChangesAsync();
                return resUser;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
