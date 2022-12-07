using Microsoft.AspNetCore.Identity;
using WhatsEat.Areas.Identity.Data;

namespace WhatsEat.Models
{
    public class Product : EntityBaseClass
    {
        public List<RecipeDetails> recipeDetails { get; set; } = new List<RecipeDetails>();
        public int productTypeId { get; set; }
        public ProductType productType { get; set; }
        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
 