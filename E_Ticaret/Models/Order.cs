using System;
using System.Collections.Generic;

namespace E_Ticaret.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public double? TotalPrice { get; set; }

    public int? ProductId { get; set; }

    public int? CardId { get; set; }
    public DateTime OrderDate { get; set; }


    public virtual Card? Card { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
