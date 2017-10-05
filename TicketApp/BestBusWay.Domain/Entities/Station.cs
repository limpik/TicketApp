using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BestBusWay.Domain.Entities
{
    public class Station
    {
        [HiddenInput(DisplayValue = false)]
        public int StationId { get; set; }

        [Display(Name = "Название станции")]
        [Required(ErrorMessage = "Введите название станции")]
        public string StName { get; set; }

        [Display(Name = "Название города")]
        [Required(ErrorMessage = "Введите название города")]
        public int CityId { get; set; }
        public City City { get; set; }

        public virtual ICollection<Route> StartStations { get; set; }
        public virtual ICollection<Route> EndStations { get; set; }
    }
}
