namespace WhatsEat.Models
{
    public class Region : EntityBaseClass
    {
        public List<Country> Countries { get; set; } = new List<Country>(); // Связь со странами (один ко многим)
    }
}
