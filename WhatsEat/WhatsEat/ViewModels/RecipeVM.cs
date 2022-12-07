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
        public List<int> productIds { get; set; } = new List<int>();
        //public List<string> productTypes { get; set; }
        public List<CheckBoxOption> Checkboxes { get; set; }
        //public int[] productIds { get; set; }
        //public IList<SelectListItem> Ingridients { get; set; }
        public SelectList SelectListRecipeTypes { get; set; }
        public SelectList SelectListCountries { get; set; }
        public SelectList SelectListDifficulties { get; set; }
        //public SelectList SelectListProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
    }
}
