using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsEat.Models
{
    public class RecipeDetails
    {
        public int Id { get; set; }
        public string shortDescription { get; set; }
        public int recipeId { get; set; }
        public Recipe recipe { get; set; }
        public int recipeTypeId { get; set; }
        public RecipeType recipeType { get; set; }
        public int countryId { get; set; }
        public Country country { get; set; }
        public List<Product> products { get; set; } = new List<Product> { };
        public string description { get; set; }
        public string difficulty { get; set; }
        public string recipeImage { get; set; }
    }
}
