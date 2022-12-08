using WhatsEat.Models;

namespace WhatsEat.Views.Fridge
{
    public class CheckBoxOption
    {
        public bool isChecked { get; set; }
        public string Name { get; set; }
        public int productId { get; set; }
        public string productTypeName { get; set; }
    }
}
