﻿using System;
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

namespace WhatsEat.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
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

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            RecipeVM recipeVM = new RecipeVM();
            recipeVM.SelectListRecipeTypes = new SelectList(_context.RecipeType.ToList(), nameof(RecipeType.Id), nameof(RecipeType.Name));
            recipeVM.SelectListCountries = new SelectList(_context.Countries.ToList(), nameof(Country.Id), nameof(Country.Name));
            recipeVM.SelectListDifficulties = new SelectList(new List<string>() { "Легко", "Нормально", "Сложно" });
            recipeVM.SelectListProducts = new SelectList(_context.Products.ToList(), nameof(Product.Id), nameof(Product.Name));
            return View(recipeVM);
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

            if (ModelState.IsValid)
            {
                Recipe recipe = new Recipe();
                RecipeDetails recipeDetails = new RecipeDetails();
                recipe.Name = recipeModel.RecipeName;
                _context.Recipes.Add(recipe);
                _context.SaveChanges();
                recipeDetails.shortDescription = recipeModel.RecipeShortDescription;
                recipeDetails.description = recipeModel.RecipeDescription;
                recipeDetails.recipeTypeId = recipeModel.RecipeTypeId;
                recipeDetails.countryId = recipeModel.CountryId;
                recipeDetails.difficulty = recipeModel.Difficulty;
                recipeDetails.recipeId = recipe.Id;
                for (int i = 0; i < recipeModel.productIds.Length; i++)
                {
                    Product product = _context.Products.ToList().Where(p => p.Id == recipeModel.productIds[i]).FirstOrDefault();
                    recipeDetails.products.Add(product);
                }
                _context.RecipeDetails.Add(recipeDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(recipeModel);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
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
