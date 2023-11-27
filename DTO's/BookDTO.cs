namespace BooksStoreWebAPI.DTO_s
{
    public class BookDTO
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> AuthorName { get; set; }
    }
}
