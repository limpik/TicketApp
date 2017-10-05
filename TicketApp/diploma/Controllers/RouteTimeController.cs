using BestBusWay.Domain.Repositories.RouteTimeRepository.Interfaces;
using System.Data.Entity;
using System.Web.Mvc;
using BestBusWay.Domain.Entities;
using System.Linq;
using System.Data;
using BestBusWay.Domain.Concrete;
using System.Collections.Generic;
using System;
using System.Data.Entity.Core.Objects;

namespace BestBusWay.WebUI.Controllers
{
    public class RouteTimeController : Controller
    {
        // GET: RouteTime
        IRouteTimeRepository repository;
        EFDbContext db = new EFDbContext();

        public RouteTimeController(IRouteTimeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            // return View(repository.RouteTimes); 
           var routetimes = db.RouteTimes.Include(r => r.Route)
                                         .Include(r => r.Route.StartStation)
                                         .Include(r => r.Route.EndStation)
                                         .Include(r => r.Route.StartStation.City)
                                         .Include(r => r.Route.EndStation.City);
           return View(routetimes.ToList());
        }

        public ViewResult Edit(int routeTimeId)
        {
            // RouteTime routeTime = repository.RouteTimes
            //    .FirstOrDefault(r => r.RouteTimeId == routeTimeId);
            //return View(routeTime);
            RouteTime routeTime = repository.RouteTimes.FirstOrDefault(g => g.RouteTimeId == routeTimeId);
              
            //SelectList routes = new SelectList(db.Routes.ToList(), "RouteId", "RouteName", routeTime.RouteId);
            ViewBag.Routes = db.Routes.ToList();
            ViewBag.City = db.Cities.ToList();
            return View(routeTime);

        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(RouteTime routeTime)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Routes = db.Routes.ToList();

                // Если что-то не так со значениями данных
                return View(routeTime);
            }
            else
            {
                repository.SaveRouteTime(routeTime);
                TempData["message"] = string.Format("Изменения в записи c ID -  \"{0}\"  в таблице \"Время маршрута\" были сохранены", routeTime.RouteTimeId);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Routes = db.Routes.ToList();

            return View("Edit", new RouteTime());
        }

        [HttpPost]
        public ActionResult Delete(int routeTimeId)
        {
            RouteTime deleteRouteTime = repository.DeleteRouteTime(routeTimeId);
            if (deleteRouteTime != null)
            {
                TempData["message"] = string.Format("Время маршрута с ID - \"{0}\" было удалено",
                    deleteRouteTime.RouteTimeId);
            }
            return RedirectToAction("Index");
        }
    }
}
