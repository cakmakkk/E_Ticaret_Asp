using System;
using System.Collections.Generic;

namespace E_Ticaret.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public bool? Role { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
