using BooksStoreWebAPI.Custom_Action_Filter;
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Author_Repository;
using BooksStoreWebAPI.Repository.Menu_Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            var result = await authorRepository.AddAuthor(author);
            if (author == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{authorId}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAuthor([FromRoute] int authorId, [FromBody] Author author)
        {
            var result = await authorRepository.UpdateAuthor(authorId, author);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {
            var result = await authorRepository.GetAllAuthors();
            return Ok(result);

        }

        [HttpGet]
        [Route("{authorId}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] int authorId)
        {
            var result = await authorRepository.GetAuthorById(authorId);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{authorId}")]
        public async Task<IActionResult> DeletAuthor([FromRoute] int authorId)
        {
            var result = await authorRepository.DeleteAuthor(authorId);
            if (result == null)
            {
                return BadRequest("No Results Found");
            }

            return Ok(result);

        }
    }

}
