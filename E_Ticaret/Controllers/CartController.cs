using E_Ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Controllers
{
    public class CartController : Controller
    {
        private readonly ETicaretDbContext context;

        public CartController(ETicaretDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Cart()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var items = context.Cards
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToList();

            return View(items);
        }

        public IActionResult AddToCart(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var varOlanUrun = context.Cards.FirstOrDefault(c => c.UserId == userId && c.ProductId == id);
            if (varOlanUrun != null)
            {
                varOlanUrun.Quantity += 1;
            }
            else
            {
                context.Cards.Add(new Card
                {
                    UserId = userId.Value,
                    ProductId = id,
                    Quantity = 1
                });
            }

            context.SaveChanges();
            return RedirectToAction("Cart");
        }

        public IActionResult Delete(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var item = context.Cards.FirstOrDefault(c => c.CardId == id && c.UserId == userId);
            if (item != null)
            {
                context.Cards.Remove(item);
                context.SaveChanges();
            }

            return RedirectToAction("Cart");
        }
    }
}
