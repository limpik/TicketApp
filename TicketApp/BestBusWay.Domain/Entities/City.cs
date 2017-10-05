using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BestBusWay.Domain.Entities
{
    public class City
    {
        [HiddenInput(DisplayValue = false)]
        public int CityId { get; set; }

        [Display(Name = "Название города")]
        [Required(ErrorMessage = "Введите название города")]
        public string CityName { get; set; } 

        [Display(Name = "Название страны")]
        [Required(ErrorMessage = "Введите название страны")]
        public string CountryName { get; set; }

        public ICollection<Station> Stations { get; set; }
    }
}
