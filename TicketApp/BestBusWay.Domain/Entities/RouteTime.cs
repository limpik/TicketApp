using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BestBusWay.Domain.Entities
{
    public class RouteTime
    {
        [HiddenInput(DisplayValue = false)]
        public int RouteTimeId { get; set; }

        [Display(Name = "Время и дата отправления")]
        [Required(ErrorMessage = "Введите время и дату отправления")]
        public DateTime TimeDeparture { get; set; }

        [Display(Name = "Время и дата прибытия")]
        [Required(ErrorMessage = "Введите время и дату прибытия")]
        public DateTime TimeArrival { get; set; }

        [Display(Name = "Маршрут")]
        public int RouteId { get; set; }
        public Route Route { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
