using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Ticaret.Models;

namespace E_Ticaret.Controllers
{
    public class ProductController : Controller
    {
        private readonly ETicaretDbContext _context;

        public ProductController(ETicaretDbContext context)
        {
            _context = context;
        }

        // 🔹 [POST] Create - Modal'dan gelen veriyi kaydet
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"❌ HATA: {entry.Key} → {error.ErrorMessage}");
                    }
                }

                return RedirectToAction("AdminPage", "Admin");
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("AdminPage", "Admin");
        }




        // 🔹 [POST] Edit - Modal değilse formdan gelen veriyi güncelle
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products.Find(updatedProduct.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = updatedProduct.ProductName;
                    existingProduct.Description = updatedProduct.Description;
                    existingProduct.Price = updatedProduct.Price;
                    existingProduct.Image = updatedProduct.Image;
                    existingProduct.CategoryId = updatedProduct.CategoryId;

                    _context.SaveChanges();
                }
            }

            return RedirectToAction("AdminPage", "Admin");
        }


        // 🔹 [GET] Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction("AdminPage", "Admin");
        }
    }
}
