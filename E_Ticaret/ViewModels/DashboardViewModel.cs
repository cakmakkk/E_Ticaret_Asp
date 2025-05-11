using E_Ticaret.Models;

namespace E_Ticaret.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalAdmins { get; set; }
        public double TotalSalesAmount { get; set; }
        public int TotalOrders { get; set; }

        public List<User> Users { get; set; } // sıralı kullanıcılar
        public List<Product> Products { get; set; } // ürün listesi
        
    }
}
