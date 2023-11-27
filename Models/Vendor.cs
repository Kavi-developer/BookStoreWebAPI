using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public int ContactId { get; set; }

    public virtual Contact? Contact { get; set; } 

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
