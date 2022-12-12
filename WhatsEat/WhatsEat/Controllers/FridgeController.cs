using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WhatsEat.Areas.Identity.Data;
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
        /// <summary>
        /// Главная страница холодильника с отображением списка имеющихся продуктов
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //Получаем айди пользователя и продукты пользователя
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ApplicationUser> products = _context.Users.Include(u => u.UserProducts).ToList();

            //Создаем и инициализируем представление
            UserFridgeVM fridgeVM = new UserFridgeVM
            {
                Products = _context.Users.Where(u => u.Id == userId).FirstOrDefault().UserProducts,
                ProductTypes = _context.ProductTypes.ToList()
            };

            //Возвращаем представление
            return View(fridgeVM);
        }

        // GET: FridgeController/AddProducts
        /// <summary>
        /// Добавление рецептов (GET)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddProducts()
        {
            //Инициализируем модель представления
            ProductVM productVM = new ProductVM
            {
                productTypes = _context.ProductTypes.ToList(),
                products = _context.Products.ToList(),
                Checkboxes = new List<CheckBoxOption>()
            };

            //Для каждого продукта создаем чекбокс
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

            //Возвращаем представление
            return View(productVM);
        }

        // POST: FridgeController/AddProducts
        /// <summary>
        /// Добавление рецептов (POST)
        /// </summary>
        /// <param name="productVM"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProducts(ProductVM productVM)
        {
            //Игнорируем валидацию некоторых свойств модели представления
            ModelState.Remove("productTypes");
            ModelState.Remove("Checkboxes");
            ModelState.Remove("products");

            //Если модель прошла валидацию
            if (ModelState.IsValid)
            {
                //Получаем текущего пользователя
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                //Добавляем каждый выбранный продукт из списка
                foreach (var productId in productVM.productIds)
                {
                    //Если у пользователя нет этого продукта, то добавить его в список продуктов пользователя
                    if (user.UserProducts.Where(p => p.Id == productId).FirstOrDefault() == null)
                    {
                        user.UserProducts.Add(_context.Products.Where(p => p.Id == productId).FirstOrDefault());
                        _context.SaveChanges();
                    }//Конец условия если
                }//Конец цикла foreach
            }//Конец условия если

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Удаление продукта (GET)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }//Конец условия если

            //Получаем текущего пользователя
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.Include(p => p.UserProducts).FirstOrDefaultAsync(m => m.Id == userId);
            
            if (user == null)
            {
                return NotFound();
            }//Конец условия если
            
            //Получаем выбранный продукт
            Product product = user.UserProducts.FirstOrDefault(p => p.Id == id);

            //Возвращаем предствление с подтверждением об удалении выбранного продукта
            return View(product);
        }

        /// <summary>
        /// Удаление продукта (POST)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            //Получаем текущего пользователя
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = _context.Users.Include(u => u.UserProducts).Where(u => u.Id == userId).FirstOrDefault();

            //Получаем выбранный продукт
            Product product = user.UserProducts.Where(p => p.Id == id).FirstOrDefault();

            //Удаляем продукт, сохраняем изменения в базе данных и перенаправляем на главную страницу контроллера 
            user.UserProducts.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
