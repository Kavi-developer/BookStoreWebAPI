using BooksStoreWebAPI.Custom_Action_Filter;
using BooksStoreWebAPI.DTO_s;
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Menu_Repository;
using BooksStoreWebAPI.Repository.User_Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRespository userRespository;
        private readonly BookDbContext bookDbContext;

        public UserController(IUserRespository userRespository,BookDbContext bookDbContext)
        {
            this.userRespository = userRespository;
            this.bookDbContext = bookDbContext;
        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddUser([FromBody]User user)
        {
          var result= await userRespository.AddUser(user);
            return Ok(result);
        }

        [HttpPut]
        [Route("{userId}")]
        [ValidateModel]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Updateuser([FromRoute] int userId, [FromBody] User user)
        {
            var result = await userRespository.UpdateUser(userId, user);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUser()
        {
            var result = bookDbContext.Users.ToList();
            return Ok(result);

        }

        [HttpGet]
        [Route("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var result = await userRespository.GetUserById(userId);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{userId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteMenu([FromRoute] int userId)
        {
            var result = await userRespository.DeleteUser(userId);
            if (result == null)
            {
                return BadRequest("No Results Found");
            }

            return Ok(result);

        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDTO)
        {
            var user= bookDbContext.Users.FirstOrDefault(a=> a.Email == loginDTO.Email);

            if(user != null)
            {
                if(user.Password == loginDTO.Password)
                {
                    return Ok("Token generating: "+ userRespository.GenerateToken(loginDTO));
                }
                else { return BadRequest(); 
                }
            }
            else
            {
                return NotFound();
            }
        }


    
    }
}
