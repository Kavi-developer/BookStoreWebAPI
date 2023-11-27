using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.Author_Repository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthors();

        Task<Author?> GetAuthorById(int authorId);

        Task<Author> AddAuthor(Author author);

        Task<Author?> UpdateAuthor(int authorId,Author author);

        Task<Author?> DeleteAuthor(int  authorId);
    }
}
