using System.ComponentModel.DataAnnotations;

namespace WhatsEat.Models
{
    /// <summary>
    /// Базовый класс для базы данных, имеющий айди и имя
    /// </summary>
    public class EntityBaseClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
