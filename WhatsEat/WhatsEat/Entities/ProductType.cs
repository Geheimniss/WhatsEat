namespace WhatsEat.Entities
{
    public class ProductType : EntityBaseClass
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
