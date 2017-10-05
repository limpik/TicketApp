using BestBusWay.Domain.Repositories.CityRepository.Interfaces;
using System.Web.Mvc;
using BestBusWay.Domain.Entities;
using System.Linq;

namespace BestBusWay.WebUI.Controllers
{
    public class CityController : Controller
    {
        // GET: City

        ICityRepository repository;

        public CityController(ICityRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Cities);
        }

        public ViewResult Edit(int cityId)
        {
            City city = repository.Cities
                .FirstOrDefault(g => g.CityId == cityId);
            return View(city);
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCity(city);
                TempData["message"] = string.Format("Изменения в городе c ID -  \"{0}\" были сохранены", city.CityId);
                return RedirectToAction("Index");
            }
            else
            {
                // Если что-то не так со значениями данных
                return View(city);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new City());
        }

        [HttpPost]
        public ActionResult Delete(int cityId)
        {
           City deleteCity = repository.DeleteCity(cityId);
           if(deleteCity != null)
            {
                TempData["message"] = string.Format("Город \"{0}\" был удален",
                    deleteCity.CityName);
            }
            return RedirectToAction("Index");
        }
    }
}