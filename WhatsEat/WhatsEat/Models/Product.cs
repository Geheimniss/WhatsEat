namespace WhatsEat.Models
{
    public class Product : EntityBaseClass
    {
        public List<RecipeDetails> recipeDetails { get; set; }
        public int productTypeId { get; set; }
        public ProductType productType { get; set; }
    }
}
