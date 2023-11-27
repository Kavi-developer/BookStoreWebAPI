using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Repository.Author_Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookDbContext context;

        public AuthorRepository(BookDbContext context)
        {
            this.context = context;
        }
                
        public async Task<Author> AddAuthor(Author author)
        {
             try
            {
                if(author == null)
                {
                    return null;
                }
               await context.Authors.AddAsync(author);
               await context.SaveChangesAsync();
                return author;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Author?> DeleteAuthor(int authorId)
        {
            try
            {
                var author = await context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
                if (author == null)
                {
                    return null;
                }
                context.Authors.Remove(author);
                await context.SaveChangesAsync();
                return author;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<List<Author>> GetAllAuthors()
        {
           return context.Authors.ToListAsync();
        }

        public async Task<Author?> GetAuthorById(int authorId)
        {
            try
            {
                var author = await context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
                if (author == null)
                {
                    return null;
                }
                return author;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Author?> UpdateAuthor(int authorId, Author author)
        {
            try
            {
                var resAuthor = await context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
                if (resAuthor == null)
                {
                    return null;
                }
                resAuthor.AuthorName = author.AuthorName;
                resAuthor.BookAuthors = author.BookAuthors;

                await context.SaveChangesAsync();
                return resAuthor;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
