using E_Ticaret.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret.Controllers
{
	public class ShopController : Controller
	{
		ETicaretDbContext context = new ETicaretDbContext();
		public IActionResult Shop()
		{
				var values = context.Products.ToList();
				return View(values);
		}
	}
}
