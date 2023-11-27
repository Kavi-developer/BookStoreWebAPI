using BooksStoreWebAPI.DTO_s;
using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Repository.Book_Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext context;

        public BookRepository(BookDbContext context)
        {
            this.context = context;
          
        }
        public async Task<Book> AddBook(Book book)
        {
            try
            {
                if(book == null)
                {
                    return null;
                }   
                await context.Books.AddAsync(book);
                context.SaveChanges();
                return book;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Book?> DeleteBookById(int bookId)
        {
            try
            {
                var book = context.Books.FirstOrDefault(a => a.BookId == bookId);

                if (book != null)
                {
                    if (book.BookAuthors != null)
                    {
                        var bookauthor = context.BookAuthors.FirstOrDefault(a => a.BookId == bookId);
                        context.BookAuthors.RemoveRange(bookauthor);
                    }

                    context.Books.Remove(book);
                    await context.SaveChangesAsync();
                    return book;
                }
                    return null;
                
            } catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await context.Books.Include(a => a.BookAuthors).ThenInclude(a => a.Author)
            .ToListAsync();
            return books;
        }

        public async Task<Book?> GetBookById(int bookId)
        {
            try
            {
               return context.Books.Include(a => a.BookAuthors).ThenInclude(a=> a.Author)
                    .FirstOrDefault(a => a.BookId == bookId);

            }
            catch(Exception ex)
            { 
                return null; 
            }
              
            
        }

        public async Task<Book?> UpdateBookById(int bookId,Book book)
        {
            try
            {
                var resBook = context.Books.FirstOrDefault(a => a.BookId == bookId);
                if (resBook != null)
                {
                    resBook.PublisherName = book.PublisherName;
                    resBook.Title = book.Title;
                    resBook.Isbn = book.Isbn;
                    resBook.BookCategoryId = book.BookCategoryId;
                    resBook.SellingPrice = book.SellingPrice;
                    resBook.Url = book.Url;

                  await context.SaveChangesAsync();
                    return book;
                }
                return null;
            }
            catch( Exception ex)
            {
                return null;
            }
        }

       
    }
}
