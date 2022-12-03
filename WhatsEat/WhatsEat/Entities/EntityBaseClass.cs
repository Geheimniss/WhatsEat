namespace WhatsEat.Entities
{
    /// <summary>
    /// Базовый класс для базы данных, имеющий айди и имя
    /// </summary>
    public class EntityBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
