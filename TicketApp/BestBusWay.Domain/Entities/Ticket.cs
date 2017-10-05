using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestBusWay.Domain.Entities
{
    public class Ticket
    {
        [HiddenInput(DisplayValue = false)]
        public int TicketId { get; set; }

        [Display(Name = "Время отправления/прибытия")]
        [Required(ErrorMessage = "Выберите время отправления/прибытия")]
        public int RouteTimeId { get; set; }

        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "Введите ваши фамилию, имя и отчество")]
        public string FullName { get; set; }

        [Display(Name = "Email-адрес")]
        [Required(ErrorMessage = "Введите ваш Email-адрес")]
        public string Email { get; set; }

        [NotMapped]
        public string TicketNum => $"{TicketId} + {new Random().Next(10)}";

        public DateTime Date { get; set; }

        public RouteTime RouteTime { get; set; }
    }

}
