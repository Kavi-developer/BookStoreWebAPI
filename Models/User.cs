using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class User 
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
