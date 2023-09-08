using System;
using System.Collections.Generic;

namespace LostAndFound.Models;

public partial class UserTable
{
    public int UserId { get; set; }

    public string EmailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<ItemTable> ItemTables { get; set; } = new List<ItemTable>();
}
