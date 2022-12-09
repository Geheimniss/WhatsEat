using WhatsEat.Areas.Identity.Data;
using WhatsEat.Models;

namespace WhatsEat.ViewModel
{
    public class UserFridgeVM
    {
        public string Name { get;set;}
        public string UserId { get;set;}
        public int? ProductId { get; set; }
        public List<Product> Products { get;set;}
        public List<ProductType> ProductTypes { get; set; }

    }
}
