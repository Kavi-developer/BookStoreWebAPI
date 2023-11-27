using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Book_Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        //GET:https://localhost:7004/api/Book
        [HttpGet]
        [Authorize(Policy = "TwoMemberPolicy")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookRepository.GetAllBooks();
            return Ok(books);
        }

      
        //GET_ID:https://localhost:7004/api/Book/{Id}
        [HttpGet]
        [Route("{BookId}")]
        [Authorize(Policy = "GuestPolicy")]
        public async Task<IActionResult> GetAllBooks([FromRoute] int BookId)
        {
            var books = await bookRepository.GetBookById(BookId);
            return Ok(books);
        }

        //ADD:https://localhost:7004/api/Book
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBooks([FromBody] Book book)
        {
            var result = bookRepository.AddBook(book);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        //UPDATE:https://localhost:7004/api/Book/{Id}
        [HttpPut]
        [Route("{BookId}")]
        [Authorize(Roles = "Specialist")]
        public async Task<IActionResult> UpdateBook([FromRoute] int BookId, [FromBody] Book book)
        {
            var result = await bookRepository.UpdateBookById(BookId, book);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        //DELETE:https://localhost:7004/api/Book/{Id}
        [HttpDelete]
        [Route("{BookId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> deleteBook(int BookId)
        {
            var result=await bookRepository.DeleteBookById(BookId);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
