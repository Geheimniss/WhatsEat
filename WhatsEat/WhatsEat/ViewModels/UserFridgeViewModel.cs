using WhatsEat.Areas.Identity.Data;
using WhatsEat.Models;

namespace WhatsEat.ViewModel
{
    public class UserFridgeViewModel
    {
        public string Name { get;set;}
        public string UserId { get;set;}
        public List<Product> Products { get;set;}
        public List<ProductType> ProductTypes { get; set; }
    }
}
