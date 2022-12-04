using Microsoft.AspNetCore.Mvc.Rendering;
using WhatsEat.Models;

namespace WhatsEat.ViewModel
{
    public class RecipeVM
    {
        public string RecipeName { get; set; }
        public string RecipeShortDescription { get; set; }
        public string RecipeDescription { get; set; }
        public int CountryId { get; set; }
        public int RecipeTypeId { get; set; }
        public string Difficulty { get; set; }
        public int[] productIds { get; set; }
        public SelectList SelectListRecipeTypes { get; set; }
        public SelectList SelectListCountries { get; set; }
        public SelectList SelectListDifficulties { get; set; }
        public SelectList SelectListProducts { get; set; }
    }
}
