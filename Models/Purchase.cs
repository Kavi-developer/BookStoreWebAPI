using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int VendorId { get; set; }

    public decimal? SalesTax { get; set; }

    public short? DiscountPercent { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal InvoiceAmount { get; set; }

    public string? InvoiceNumber { get; set; }

    public string? InvoiceUrl { get; set; }

    public virtual ICollection<PurchaseDetail>? PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual Vendor? Vendor { get; set; } 
}
