namespace WhatsEat.Models
{
    /// <summary>
    /// Рецепт
    /// </summary>
    public class Recipe : EntityBaseClass
    {
        public RecipeDetails recipeDetails { get; set; }
    }
}
