using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string ContactName { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
