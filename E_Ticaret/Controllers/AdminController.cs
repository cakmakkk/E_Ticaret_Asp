using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using E_Ticaret.Models;
using System.Linq;
using E_Ticaret.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Ticaret.Controllers
{
    public class AdminController : Controller
    {
        private readonly ETicaretDbContext _context;

        public AdminController(ETicaretDbContext context)
        {
            _context = context;
        }

        public IActionResult AdminPage()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin")
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();

            var model = new DashboardViewModel
            {
                TotalUsers = _context.Users.Count(u => u.Role == false),
                TotalAdmins = _context.Users.Count(u => u.Role == true),
                TotalSalesAmount = _context.Orders.Sum(o => o.TotalPrice) ?? 0,
                TotalOrders = _context.Orders.Count(),
                Users = _context.Users.OrderByDescending(u => u.Role).ToList(),
                Products = _context.Products.Include(p => p.Category).ToList()
            };

            return View(model);
        }


    }
}
