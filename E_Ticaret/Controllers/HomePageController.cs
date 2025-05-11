using E_Ticaret.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret.Controllers
{
    public class HomePageController : Controller
    {
        ETicaretDbContext context=new ETicaretDbContext();
        [HttpGet]
        public IActionResult Index()
        {
            var values=context.Products.OrderByDescending(x=>x.ProductId).Take(3).ToList();
            return View(values);
        }
    }
}
