namespace WhatsEat.Entities
{
    public class Country : EntityBaseClass
    {
        public int regionId { get; set; }
        public Region region { get; set; }  // Связь с регионами (один ко многим)
    }
}
