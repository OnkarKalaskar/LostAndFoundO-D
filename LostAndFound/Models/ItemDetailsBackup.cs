using System;
using System.Collections.Generic;

namespace LostAndFound.Models;

public partial class ItemDetailsBackup
{
    public int BackUpId { get; set; }

    public int? ItemTableId { get; set; }

    public string TypeOfOperation { get; set; } = null!;

    public DateTime? TimeStamp { get; set; }

    public DateTime? DeleteDate { get; set; }

    public virtual ItemTable? ItemTable { get; set; }
}
