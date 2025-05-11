using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Models;

public partial class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Ürün adı zorunludur.")]
    public string ProductName { get; set; }

    public string? Description { get; set; }

    [Required(ErrorMessage = "Fiyat zorunludur.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
    public double Price { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Kategori seçilmelidir.")]
    public int CategoryId { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
