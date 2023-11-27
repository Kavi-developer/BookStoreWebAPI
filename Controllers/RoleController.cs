using BooksStoreWebAPI.Custom_Action_Filter;
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Menu_Repository;
using BooksStoreWebAPI.Repository.Role_Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            var result = await roleRepository.AddRole(role);
            if (role == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{roleId}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRole([FromRoute] int roleId, [FromBody] Role role)
        {
            var result = await roleRepository.UpdateRole(roleId, role);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllmenu()
        {
            var result = await roleRepository.GetAllRoles();
            return Ok(result);

        }

        [HttpGet]
        [Route("{roleId}")]
        public async Task<IActionResult> GetRoleById([FromRoute] int roleId)
        {
            var result = await roleRepository.GetRoleById(roleId);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{roleId}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int roleId)
        {
            var result = await roleRepository.DeleteRole(roleId);
            if (result == null)
            {
                return BadRequest("No Results Found");
            }

            return Ok(result);

        }
    }

}

