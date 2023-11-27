using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<RoleRight>? RoleRights { get; set; } = new List<RoleRight>();

    public virtual ICollection<User>? Users { get; set; } = new List<User>();
}
