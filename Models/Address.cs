using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? AddressDetail { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
