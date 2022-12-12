using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsEat.Models
{
    /// <summary>
    /// Модель описывающая страну
    /// </summary>
    public class Country : EntityBaseClass
    {
        public int regionId { get; set; }
        public Region region { get; set; }  // Связь с регионами (один ко многим)
    }
}
