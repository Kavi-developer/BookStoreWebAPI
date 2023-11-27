using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BooksStoreWebAPI.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string PublisherName { get; set; } = null!;

    public int BookCategoryId { get; set; }

    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public decimal SellingPrice { get; set; }

    public int? Inventory { get; set; }

    public string? Url { get; set; }

    public  ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public BookCategory? BookCategory { get; set; } 

    public  ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
