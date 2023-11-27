using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public int? ContactId { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
