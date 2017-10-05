using System.Linq;
using System.Web.Mvc;
using BestBusWay.Domain.Repositories.OrderRepository.Interfaces;
using BestBusWay.Domain.Entities;
using System.Web;

namespace BestBusWay.WebUI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        IOrderRepository repository;

        public OrderController(IOrderRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Orders);
        }

        [HttpGet]
        public ViewResult Edit(int orderId)
        {
            Order order = repository.Orders
                .FirstOrDefault(o => o.OrderId == orderId);
            return View(order);

        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                repository.SaveOrder(order);
                TempData["message"] = string.Format("Изменения в заказе \"{0}\" быди сохранены", order.OrderId);
                return RedirectToAction("Index");
            }
            else
            {
                // Если что-то не так со значениями данных
                return View(order);
            }
        }
        
    }
}