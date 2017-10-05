using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BestBusWay.Domain.Entities
{
    public class Bus
    {
        [HiddenInput(DisplayValue = false)]
        public int BusId { get; set; }

        [Display(Name = "Название автобуса")]
        [Required(ErrorMessage = "Введите название автобуса")]
        public string Name { get; set; }

        [Display(Name = "Количество мест")]
        [Required(ErrorMessage = "Введите количество мест")]
        public int AmountPlaces { get; set; }

        public ICollection<Route> Routes { get; set; }
 
    }
}
