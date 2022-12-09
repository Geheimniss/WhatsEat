using Microsoft.AspNetCore.Mvc.Rendering;
using WhatsEat.Models;

namespace WhatsEat.ViewModel
{
    public class RecipesListVM
    {
        public IEnumerable<Recipe> Recipes { get; set; } = new List<Recipe>();
        public string RecipeName { get; set; }
        public SelectList RecipeTypes { get; set; } = new SelectList(new List<RecipeType>(), "Id", "Name");
        public SelectList Countries { get; set; } = new SelectList(new List<Country>(), "Id", "Name");
        public SelectList Difficulties { get; set; }
        
    }
}
