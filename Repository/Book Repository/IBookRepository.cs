using BooksStoreWebAPI.DTO_s;
using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.Book_Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBookById(int bookId);
        Task<Book> AddBook(Book book);
        Task<Book?> UpdateBookById(int bookId,Book book);
        Task<Book?> DeleteBookById(int bookId);
    }
}
