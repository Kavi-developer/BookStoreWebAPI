using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string MenuText { get; set; } = null!;

    public string? Url { get; set; }

    public virtual ICollection<RoleRight>? RoleRights { get; set; } = new List<RoleRight>();
}
