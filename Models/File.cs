using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class File
{
    public int FileId { get; set; }

    public string Location { get; set; } = null!;

    public bool IsActive { get; set; }
}
