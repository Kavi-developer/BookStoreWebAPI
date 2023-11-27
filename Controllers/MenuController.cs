using BooksStoreWebAPI.Custom_Action_Filter;
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Menu_Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddMenu([FromBody] Menu menu)
        {
            var result= await menuRepository.AddMenu(menu);
            if(menu == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{menuId}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateMenu([FromRoute]int menuId,[FromBody] Menu menu)
        {
            var result = await menuRepository.UpdateMenuById(menuId,menu);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllmenu()
        {
            var result=await menuRepository.GetAllMenu();
            return Ok(result);

        }

        [HttpGet]
        [Route("{menuId}")]
        public async Task<IActionResult> GetMenuById([FromRoute]int menuid)
        {
            var result =await menuRepository.GetMenuById(menuid);
            if(result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{menuId}")]
        public async Task<IActionResult> DeleteMenu([FromRoute] int menuid)
        {
            var result =await menuRepository.DeleteMenuById(menuid);
            if (result == null)
            {
                return BadRequest("No Results Found");
            }

            return Ok(result);

        }
    }
}
