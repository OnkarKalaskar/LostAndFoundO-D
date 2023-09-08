using System;
using System.Collections.Generic;

namespace LostAndFound.Models;

public partial class ItemTable
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string FoundSeatLocation { get; set; } = null!;

    public string FloorNumber { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public bool? IsFound { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<ItemDetailsBackup> ItemDetailsBackups { get; set; } = new List<ItemDetailsBackup>();

    public virtual UserTable? User { get; set; }
}
