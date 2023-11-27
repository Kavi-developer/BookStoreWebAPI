using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? EmployeeName { get; set; }

    public string? Skill { get; set; }

    public string? Email { get; set; }

    public float Salary { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
