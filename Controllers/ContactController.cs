using BooksStoreWebAPI.Custom_Action_Filter;
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Contact_Repository;
using BooksStoreWebAPI.Repository.Menu_Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddMenu([FromBody] Contact contact)
        {
            var result = await contactRepository.AddContact(contact);
            if (contact == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{contactId}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateMenu([FromRoute] int contactId, [FromBody] Contact contact)
        {
            var result = await contactRepository.UpdateContact(contactId, contact);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllmenu()
        {
            var result = await contactRepository.GetAllContacts();
            return Ok(result);

        }

        [HttpGet]
        [Route("{contactId}")]
        public async Task<IActionResult> GetMenuById([FromRoute] int contactId)
        {
            var result = await contactRepository.GetContactById(contactId);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{contactId}")]
        public async Task<IActionResult> DeleteMenu([FromRoute] int contactId)
        {
            var result = await contactRepository.DeleteContact(contactId);
            if (result == null)
            {
                return BadRequest("No Results Found");
            }

            return Ok(result);

        }
    }
}
