using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestBusWay.Domain.Entities
{
    public class Route
    {
        [HiddenInput(DisplayValue = false)]
        public int RouteId { get; set; }

        [Display(Name = "Стоимость билета")]
        [Required(ErrorMessage = "Введите стоимость билета")]
        public double Price { get; set; }

        [Display(Name = "Станция отправления")]
        [Required(ErrorMessage = "Выберите название станции")]
        public int StartStationId { get; set; }

        [Display(Name = "Станция прибытия")]
        [Required(ErrorMessage = "Выберите название станции")]
        public int EndStationId { get; set; }

        [Display(Name = "Название автобуса")]
        [Required(ErrorMessage = "Введите название автобуса")]
        public int BusId { get; set; }

        public virtual Station StartStation { get; set; }
        public virtual Station EndStation { get; set; }
        public virtual Bus Bus { get; set; }

        public virtual ICollection<RouteTime> RouteTimes { get; set; }

    }
}
