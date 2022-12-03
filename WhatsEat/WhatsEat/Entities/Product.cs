namespace WhatsEat.Entities
{
    public class Product : EntityBaseClass
    {
        public int productTypeId { get; set; }
        public ProductType productType { get; set; }
        public List<Recipe> recipesDetails { get; set; } = new List<Recipe>();
    }
}
