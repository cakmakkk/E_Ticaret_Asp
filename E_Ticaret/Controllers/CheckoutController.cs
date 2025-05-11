using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using E_Ticaret.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace E_Ticaret.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ETicaretDbContext _context;

        public CheckoutController(ETicaretDbContext context)
        {
            _context = context;
        }

        // 🔹 Siparişi Tamamla
        public IActionResult Checkout()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "User");

            var cartItems = _context.Cards
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToList();

            if (!cartItems.Any())
                return RedirectToAction("Cart", "Cart");

            var now = DateTime.Now;

            foreach (var item in cartItems)
            {
                var order = new Order
                {
                    UserId = item.UserId,
                    ProductId = item.ProductId,
                    CardId = item.CardId,
                    TotalPrice = item.Quantity * item.Product.Price,
                    OrderDate = now // tüm ürünler aynı sipariş zamanıyla eşleştirilsin
                };

                _context.Orders.Add(order);
            }

            _context.Cards.RemoveRange(cartItems); // sepeti boşalt
            _context.SaveChanges();

            return RedirectToAction("MyOrders");
        }

        // 🔹 Siparişlerim Sayfası
        public IActionResult MyOrders()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "User");

            var orders = _context.Orders
                .Include(o => o.Product)
                .Include(o => o.Card)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return View(orders);
        }
    }
}
