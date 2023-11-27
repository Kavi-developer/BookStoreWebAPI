using System;
using System.Collections.Generic;

namespace BooksStoreWebAPI.Models;

public partial class EmailSendList
{
    public int EmailSendListId { get; set; }

    public string EmailFrom { get; set; } = null!;

    public string EmailToList { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string? Body { get; set; }

    public bool IsHtml { get; set; }

    public bool HasBeenSent { get; set; }

    public string? Attachment { get; set; }
}
