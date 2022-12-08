using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WhatsEat.Areas.Identity.Data;
using WhatsEat.Models;
using WhatsEat.ViewModel;
using WhatsEat.ViewModels;
using WhatsEat.Views.Fridge;

namespace WhatsEat.Controllers
{
    public class FridgeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FridgeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FridgeController
        public IActionResult Index()
        {
            UserFridgeViewModel fridgeVM = new UserFridgeViewModel();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var products = _context.Users.Include(u => u.UserProducts).ToList();
            fridgeVM.Products = _context.Users.Where(u => u.Id == userId).FirstOrDefault().UserProducts;
            fridgeVM.ProductTypes = _context.ProductTypes.ToList();
            return View(fridgeVM);
        }

        // GET: FridgeController/AddProducts
        [HttpGet]
        public IActionResult AddProducts()
        {
            ProductVM productVM = new ProductVM();
            productVM.productTypes = _context.ProductTypes.ToList();
            productVM.products = _context.Products.ToList();
            productVM.Checkboxes = new List<CheckBoxOption>();
            foreach (Product product in productVM.products)
            {
                productVM.Checkboxes.Add(new CheckBoxOption()
                {
                    isChecked = false,
                    Name = product.Name,
                    productId = product.Id,
                    productTypeName = product.productType.Name
                });
            }
            return View(productVM);
        }

        // POST: FridgeController/AddProducts
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddProducts(ProductVM productVM)
        {
            ModelState.Remove("productTypes");
            ModelState.Remove("Checkboxes");
            ModelState.Remove("products");

            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                foreach (var productId in productVM.productIds)
                {
                    if (user.UserProducts.Where(p => p.Id == productId).FirstOrDefault() != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        user.UserProducts.Add(_context.Products.Where(p => p.Id == productId).FirstOrDefault());
                        _context.SaveChanges();
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: FridgeController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: FridgeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FridgeController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: FridgeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
