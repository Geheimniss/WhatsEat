using WhatsEat.Models;
using WhatsEat.Views.Fridge;

namespace WhatsEat.ViewModel
{
    public class ProductVM
    {
        public List<ProductType> productTypes { get; set; } = new List<ProductType>();
        public List<int> productIds { get; set; }
        public List<CheckBoxOption> Checkboxes { get; set; } = new List<CheckBoxOption>();
        public List<Product> products { get; set; } = new List<Product>();

    }
}
