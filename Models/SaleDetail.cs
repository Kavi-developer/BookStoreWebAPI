using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class SaleDetail
{
    public int SaleDetailId { get; set; }

    public int SaleId { get; set; }

    public int BookId { get; set; }

    public short Quantity { get; set; }

    public decimal Rate { get; set; }

    public decimal? Amount { get; set; }

    public virtual Book? Book { get; set; } 

    public virtual Sale? Sale { get; set; } 
}
