using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhatsEat.Areas.Identity.Data;
using WhatsEat.Models;
using WhatsEat.ViewModel;
using System.Security.Cryptography.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using WhatsEat.Views.Fridge;

namespace WhatsEat.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RecipesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = _context.Recipes.Include(r => r.recipeDetails).Where(r => r.Id == id).FirstOrDefault();
            recipe.recipeDetails = _context.RecipeDetails.Include(r => r.products).Where(r => r.Id == recipe.recipeDetails.Id).FirstOrDefault();

            if (recipe == null)
            {
                return NotFound();
            }

            RecipeVM vm = new RecipeVM();
            vm.RecipeId = recipe.Id;
            vm.RecipeName = recipe.Name;
            vm.RecipeShortDescription = recipe.recipeDetails.shortDescription;
            vm.RecipeDescription = recipe.recipeDetails.description;
            vm.Difficulty = recipe.recipeDetails.difficulty;
            vm.Products = recipe.recipeDetails.products;
            recipe.recipeDetails = _context.RecipeDetails.Include(r => r.country).Where(r => r.Id == recipe.recipeDetails.Id).FirstOrDefault();
            vm.Country = recipe.recipeDetails.country;
            vm.RecipeImage = recipe.recipeDetails.recipeImage;
            return View(vm);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            //ICollection<Product> products = _context.Products.ToList();
            //RecipeVM recipeVM = new RecipeVM();
            //var ingridientsItems = products.Select(ingredient => new SelectListItem(ingredient.Name, ingredient.Id.ToString(), false));
            //recipeVM.productTypes = FillProductTypesList();
            //recipeVM.Checkboxes = FillCheckboxList();
            //return View(recipeVM);

            //IQueryable<Product> products = _context.Products.Include(p => p.productType);
            ////Если есть такой айди типа продукта, то получаем все продукты, которые имеют такой тип
            //if (productType != null && productType != 0)
            //{
            //    products = products.Where(p => p.productTypeId == productType);
            //}//конец if
            ////Если строка для имени не пустая, то еще дальше фильтрация идет по введенному имени продукта
            //if (!String.IsNullOrEmpty(name))
            //{
            //    products = products.Where(p => p.Name.Contains(name));
            //}//конец if



            //Инициализируем объект для модели представления, который будет передан в представление
            RecipeVM vm = new RecipeVM();
            vm.Products = _context.Products.ToList();
            vm.Checkboxes = new List<CheckBoxOption>();

            vm.ProductTypes = _context.ProductTypes.ToList();
            vm.SelectListRecipeTypes = new SelectList(_context.RecipeType.ToList(), nameof(RecipeType.Id), nameof(RecipeType.Name));
            vm.SelectListCountries = new SelectList(_context.Countries.ToList(), nameof(Country.Id), nameof(Country.Name));
            vm.SelectListDifficulties = new SelectList(new List<string>() { "Легко", "Нормально", "Сложно" });

            //Для каждого продукта в модели представлении, создаем свой чекбокс
            foreach (Product item in vm.Products)
            {
                vm.Checkboxes.Add(new CheckBoxOption()
                {
                    isChecked = false,
                    Name = item.Name,
                    productId = item.Id,
                    productTypeName = item.productType.Name
                });
            }
            return View(vm);
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeVM recipeModel)
        {
            ModelState.Remove("SelectListRecipeTypes");
            ModelState.Remove("SelectListCountries");
            ModelState.Remove("SelectListDifficulties");
            ModelState.Remove("SelectListProducts");
            ModelState.Remove("ProductTypes");
            ModelState.Remove("Products");
            ModelState.Remove("Name");
            ModelState.Remove("ProductIds");
            ModelState.Remove("Checkboxes");
            ModelState.Remove("Country");
            ModelState.Remove("Id");
            ModelState.Remove("RecipeImage");
            if (ModelState.IsValid)
            {
                Recipe recipe = new Recipe();
                RecipeDetails recipeDetails = new RecipeDetails();
                if (recipeModel.Photo != null)
                {
                    string folder = "images/recipeimages/";
                    folder += Guid.NewGuid().ToString() + recipeModel.Photo.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await recipeModel.Photo.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    recipeDetails.recipeImage = "/" + folder;
                }
                recipe.Name = recipeModel.RecipeName;
                _context.Recipes.Add(recipe);
                _context.SaveChanges();
                recipeDetails.shortDescription = recipeModel.RecipeShortDescription;
                recipeDetails.description = recipeModel.RecipeDescription;
                recipeDetails.recipeTypeId = recipeModel.RecipeTypeId;
                recipeDetails.countryId = recipeModel.CountryId;
                recipeDetails.difficulty = recipeModel.Difficulty;
                recipeDetails.recipeId = _context.Recipes.Where(r => r.Name == recipeModel.RecipeName).FirstOrDefault().Id;
                for (int i = 0; i < recipeModel.productIds.Count; i++)
                {
                    Product product = _context.Products.ToList().Where(p => p.Id == recipeModel.productIds[i]).FirstOrDefault();
                    recipeDetails.products.Add(product);
                }
                recipeDetails.recipe = recipe;
                _context.RecipeDetails.Add(recipeDetails);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(recipeModel);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.recipes'  is null.");
            }
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
