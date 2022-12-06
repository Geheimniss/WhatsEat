using WhatsEat.Models;

namespace WhatsEat
{
    public class CheckBoxOption
    {
        public bool isChecked { get; set; }
        public string Name { get; set; }
        public int productId { get; set; }
        public string productTypeName { get; set; }
    }
}
