using BestBusWay.Domain.Repositories.BusRepository.Interfaces;
using System.Web.Mvc;
using BestBusWay.Domain.Entities;
using System.Linq;

namespace BestBusWay.WebUI.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        IBusRepository repository;

        public BusController(IBusRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Buses);
        }

        public ViewResult Edit(int busId)
        {
            Bus bus = repository.Buses
                      .FirstOrDefault(b => b.BusId == busId);
            return View(bus);
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Bus bus)
        {
            if(ModelState.IsValid)
            {
                repository.SaveBus(bus);
                TempData["message"] = string.Format("Изменения в записи c ID -  \"{0}\"  в таблице \"Автобусы\" были сохранены", bus.BusId);
                return RedirectToAction("Index");
            }
            else
            {
                // Если что-то не так со значениями данных
                return View(bus);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Bus());
        }

        [HttpPost]
        public ActionResult Delete(int busId)
        {
            Bus deleteBus = repository.DeleteBus(busId);
            if (deleteBus != null)
            {
                TempData["message"] = string.Format("Автобус \"{0}\" был удален",
                    deleteBus.Name);
            }
            return RedirectToAction("Index");
        }
    }
}