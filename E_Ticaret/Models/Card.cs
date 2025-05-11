using System;
using System.Collections.Generic;

namespace E_Ticaret.Models;

public partial class Card
{
    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public int CardId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
