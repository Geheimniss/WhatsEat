namespace WhatsEat.Entities
{
    public class RecipeType : EntityBaseClass
    {
        public int recipeId { get; set; }
        public List<Recipe> recipes { get; set; } = new List<Recipe>();
        public List<RecipeDetails> recipeDetails { get; set; } = new List<RecipeDetails>();
    }
}
