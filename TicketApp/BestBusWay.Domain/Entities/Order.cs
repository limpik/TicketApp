using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BestBusWay.Domain.Entities
{
    public class Order
    {
        [HiddenInput(DisplayValue=false)]
        public int OrderId { get; set; }

        [Display(Name = "Дата заказа")]
        [Required(ErrorMessage = "Введите дату заказа")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "ID билета")]
        [Required(ErrorMessage = "Введите ID билета")]
        public int TicketId { get; set; }

        [Display(Name = "ID пользователя")]
        [Required(ErrorMessage = "Введите пользователя")]
        public int UserId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public User User { get; set; }
    }
}
