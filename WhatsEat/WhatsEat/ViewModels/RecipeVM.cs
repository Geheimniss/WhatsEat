using Microsoft.AspNetCore.Mvc.Rendering;
using WhatsEat.Models;
using WhatsEat.Views.Fridge;

namespace WhatsEat.ViewModel
{
    public class RecipeVM
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeShortDescription { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeImage { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int RecipeTypeId { get; set; }
        public string Difficulty { get; set; }
        public List<int> productIds { get; set; }
        public List<CheckBoxOption> Checkboxes { get; set; }
        public SelectList SelectListRecipeTypes { get; set; }
        public SelectList SelectListCountries { get; set; }
        public SelectList SelectListDifficulties { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IFormFile Photo { get; set; }
    }
}
