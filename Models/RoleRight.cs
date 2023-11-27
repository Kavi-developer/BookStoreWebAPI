using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class RoleRight
{
    public int RoleRightId { get; set; }

    public int RoleId { get; set; }

    public int MenuId { get; set; }

    public string Right { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
