using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatsEat.Models;
using WhatsEat.ViewModel;
using Microsoft.AspNetCore.Authorization;
using WhatsEat.DbContext;
using WhatsEat.Core;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using WhatsEat.Views.Fridge;

namespace WhatsEat.Controllers
{
    /// <summary>
    /// Контроллер для рецептов
    /// </summary>
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;             //Контекст базы данных
        private readonly IWebHostEnvironment _webHostEnvironment;   //Веб-хост

        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        /// <param name="context"></param>
        /// <param name="webHostEnvironment"></param>
        public RecipesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Recipes
        public async Task<IActionResult> Index(string? recipeName, int? recipeTypeId, int? countryId, string? difficulty)
        {
            //Получаем все рецепты
            IQueryable<Recipe> recipes = _context.Recipes.Include(r => r.recipeDetails).ThenInclude(c => c.country);

            //Если тип рецепта выбран, то получаем все рецепты выбранного типа
            if (recipeTypeId != null && recipeTypeId != 0)
            {
                recipes = recipes.Where(p => p.recipeDetails.country.Id == recipeTypeId);
            }//Конец условия если

            //Если страна рецепта выбрана, то получаем все рецепты страны
            if (countryId != null && countryId != 0)
            {
                recipes = recipes.Where(r => r.recipeDetails.countryId == countryId);
            }//Конец условия если

            //Если сложность рецепта выбрана, то получаем все рецепты данной сложности
            if (!string.IsNullOrEmpty(difficulty) && difficulty != "Любая")
            {
                recipes = recipes.Where(r => r.recipeDetails.difficulty == difficulty);
            }//Конец условия если

            //Если название рецепта введено, то получаем все рецепты совпадающие с введенным
            if (!string.IsNullOrEmpty(recipeName))
            {
                recipes = recipes.Where(p => p.Name!.Contains(recipeName));
            }//Конец условия если

            //Получаем данные из базы данных.
            List<RecipeType> recipeTypes = await _context.RecipeType.ToListAsync();
            List<Country> countries = await _context.Countries.ToListAsync();
            List<string> difficulties = new List<string>() { "Легко", "Нормально", "Сложно" };

            //Добавляем возможность не выбирать что-то конкретное в чек листах
            recipeTypes.Insert(0, new RecipeType { Name = "Все виды", Id = 0 });
            difficulties.Insert(0, "Любая");
            countries.Insert(0, new Country { Name = "Все страны", Id = 0 });

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var ingredients = _context.Products.ToList();
            foreach(var item in ingredients)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                selectListItems.Add(selectList);
            }
            ViewBag.Ingredients = new SelectList(selectListItems, "Value", "Text");

            //Инициализируем модель представления с фильтрованными данными
            RecipesListVM vm = new RecipesListVM
            {
                Recipes = recipes,
                Countries = new SelectList(countries, "Id", "Name", countryId),
                Difficulties = new SelectList(difficulties, "Name"),
                RecipeTypes = new SelectList(recipeTypes, "Id", "Name", recipeTypeId)
            };

            //Отправляем пользователю представление с моделью представления
            return View(vm);
        }

        // GET: Recipes/Details/5
        /// <summary>
        /// Детали о выбранном рецепте
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }//Конец условия если

            //Получаем рецепт, а также его детали из базы данных
            var recipe = _context.Recipes.Include(r => r.recipeDetails).Where(r => r.Id == id).FirstOrDefault();
            recipe.recipeDetails = _context.RecipeDetails.Include(r => r.products).Where(r => r.Id == recipe.recipeDetails.Id).FirstOrDefault();

            if (recipe == null)
            {
                return NotFound();
            }//Конец условия если

            //Создаем модель представления, в которой будет хранится весь рецепт и его описание
            RecipeVM vm = new RecipeVM
            {
                RecipeId = recipe.Id,
                RecipeName = recipe.Name,
                RecipeShortDescription = recipe.recipeDetails.shortDescription,
                RecipeDescription = recipe.recipeDetails.description,
                Difficulty = recipe.recipeDetails.difficulty,
                Products = recipe.recipeDetails.products,
                Country = recipe.recipeDetails.country,
                RecipeImage = recipe.recipeDetails.recipeImage
            };

            //Возвращаем пользователю представление
            return View(vm);
        }

        // GET: Recipes/Create
        [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.Manager}")]
        public IActionResult Create()
        {
            //Инициализируем объект для модели представления, который будет передан в представление
            RecipeVM vm = new RecipeVM
            {
                Products = _context.Products.ToList(),
                Checkboxes = new List<CheckBoxOption>(),
                ProductTypes = _context.ProductTypes.ToList(),
                SelectListRecipeTypes = new SelectList(_context.RecipeType.ToList(), nameof(RecipeType.Id), nameof(RecipeType.Name)),
                SelectListCountries = new SelectList(_context.Countries.ToList(), nameof(Country.Id), nameof(Country.Name)),
                SelectListDifficulties = new SelectList(new List<string>() { "Легко", "Нормально", "Сложно" })
            };

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
            }//Конец цикла foreach

            //Возвращаем модель в представление пользователю
            return View(vm);
        }

        // POST: Recipes/Create
        /// <summary>
        /// Добавление нового рецепта в БД
        /// </summary>
        /// <param name="recipeModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.Manager}")]
        public async Task<IActionResult> Create(RecipeVM recipeModel)
        {
            //Убираем валидацию для некоторых свойств модели представления
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

            //Если модель проходит валидацию
            if (ModelState.IsValid)
            {
                //Если существует рецепт с таким названием, то перенаправить в главную страницу контроллера
                if (_context.Recipes.Where(r => r.Name == recipeModel.RecipeName).FirstOrDefault() != null)
                {
                    return RedirectToAction(nameof(Index));
                }//Конец условия если

                //Инициализируем рецепт и детали для него
                Recipe recipe = new Recipe();
                RecipeDetails recipeDetails = new RecipeDetails();

                //Если картинка была загружена, то привязываем ее к рецепту
                if (recipeModel.Photo != null)
                {
                    string folder = "images/recipeimages/";
                    folder += Guid.NewGuid().ToString() + recipeModel.Photo.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await recipeModel.Photo.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    recipeDetails.recipeImage = "/" + folder;
                }//Конец условия если
                else //Если картинка не загружена, то устанавливаем стандартную иконку для рецептов
                {
                    recipeDetails.recipeImage = "/images/recipeimages/defaultRecipeImage.png";
                }//Конец условия тогда

                //Даем рецепту имя получаемое из модели и сохраняем в бд
                recipe.Name = recipeModel.RecipeName;
                _context.Recipes.Add(recipe);
                _context.SaveChanges();

                //Даем деталям рецепты данные, получаемые из модели
                recipeDetails.shortDescription = recipeModel.RecipeShortDescription;
                recipeDetails.description = recipeModel.RecipeDescription;
                recipeDetails.recipeTypeId = recipeModel.RecipeTypeId;
                recipeDetails.countryId = recipeModel.CountryId;
                recipeDetails.difficulty = recipeModel.Difficulty;
                recipeDetails.recipeId = _context.Recipes.Where(r => r.Name == recipeModel.RecipeName).FirstOrDefault().Id;

                //Добавляем в детали рецепта все выбранные в представлении ингредиенты
                for (int i = 0; i < recipeModel.productIds.Count; i++)
                {
                    Product product = _context.Products.ToList().Where(p => p.Id == recipeModel.productIds[i]).FirstOrDefault();
                    recipeDetails.products.Add(product);
                }//Конец цикла

                //Сохраняем в бд
                recipeDetails.recipe = recipe;
                _context.RecipeDetails.Add(recipeDetails);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }//Конец условия если

            return View(recipeModel);
        }

        // GET: Recipes/Delete/5
        /// <summary>
        /// Удаление рецепта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.Manager}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }//Конец условия если

            //Получаем рецепт из базы данных
            Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }//Конец условия если

            //Возвращаем представление с подтверждением об удалении
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        /// <summary>
        /// Удаление рецепта было подтверждено
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.Manager}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.recipes'  is null.");
            }//Конец условия если

            //Находим рецепт
            Recipe recipe = await _context.Recipes.FindAsync(id);
            //И если рецепт не null, то удаляем
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
            }//Конец условия если

            //Сохраняем бд и перенаправляем на главную страницу контроллера
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
