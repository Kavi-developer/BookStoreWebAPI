using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class PurchaseDetail
{
    public int PurchaseDetailId { get; set; }

    public int PurchaseId { get; set; }

    public int BookId { get; set; }

    public short Quantity { get; set; }

    public decimal Rate { get; set; }

    public decimal? Amount { get; set; }

    public virtual Book? Book { get; set; } 

    public virtual Purchase? Purchase { get; set; } 
}
