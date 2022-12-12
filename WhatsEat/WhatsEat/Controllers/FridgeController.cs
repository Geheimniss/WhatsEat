using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WhatsEat.Core;
using WhatsEat.DbContext;
using WhatsEat.Models;
using WhatsEat.ViewModel;
using WhatsEat.Views.Fridge;

namespace WhatsEat.Controllers
{
    [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.Manager}, {Constants.Roles.User}")]
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
            UserFridgeVM fridgeVM = new UserFridgeVM();
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
                    if (user.UserProducts.Where(p => p.Id == productId).FirstOrDefault() == null)
                    {
                        user.UserProducts.Add(_context.Products.Where(p => p.Id == productId).FirstOrDefault());
                        _context.SaveChanges();
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _context.Users.Include(p=>p.UserProducts).FirstOrDefaultAsync(m => m.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            var product = user.UserProducts.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Include(u => u.UserProducts).Where(u=>u.Id == userId).FirstOrDefault();
            var product = user.UserProducts.Where(p=>p.Id == id).FirstOrDefault();
            user.UserProducts.Where(p=>p.Id == id).FirstOrDefault();
            return RedirectToAction(nameof(Index));
        }
        //// GET: FridgeController/Edit/5
        //public IActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: FridgeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
