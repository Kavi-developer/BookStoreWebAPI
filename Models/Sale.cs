using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int CustomerId { get; set; }

    public decimal? SalesTax { get; set; }

    public short? DiscountPercent { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal InvoiceAmount { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<SaleDetail>? SaleDetails { get; set; } = new List<SaleDetail>();
}
