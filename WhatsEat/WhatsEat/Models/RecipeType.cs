namespace WhatsEat.Models
{
    /// <summary>
    /// Тип рецепта
    /// </summary>
    public class RecipeType : EntityBaseClass
    {
        public List<RecipeDetails> recipeDetails { get; set; } = new List<RecipeDetails>();
    }
}
