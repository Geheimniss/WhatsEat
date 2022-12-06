namespace WhatsEat.Models
{
    public class RecipeType : EntityBaseClass
    {
        public List<RecipeDetails> recipeDetails { get; set; } = new List<RecipeDetails>();
    }
}
