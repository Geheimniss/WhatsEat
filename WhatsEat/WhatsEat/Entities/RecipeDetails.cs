namespace WhatsEat.Entities
{
    public class RecipeDetails
    {
        public int Id { get; set; }
        public string shortDescription { get; set; }
        public int recipeId { get; set; }
        public Recipe recipe { get; set; }
        public RecipeType recipeType { get; set; }
        public Country country { get; set; }
        public List<Product> products { get; set; }
        public string description { get; set; }
        public string difficulty { get; set; }
    }
}
