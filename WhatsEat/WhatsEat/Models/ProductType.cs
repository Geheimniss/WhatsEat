namespace WhatsEat.Models
{
    /// <summary>
    /// Тип продукта
    /// </summary>
    public class ProductType : EntityBaseClass
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
