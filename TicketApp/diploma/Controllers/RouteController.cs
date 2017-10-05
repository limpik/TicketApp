using BestBusWay.Domain.Repositories.RouteRepository.Interfaces;
using System.Data.Entity;
using System.Web.Mvc;
using BestBusWay.Domain.Entities;
using System.Linq;
using System.Data;
using BestBusWay.Domain.Concrete;
using System.Collections.Generic;
using System;
using WebGrease.Css.Extensions;
using System.Data.Entity.Core.Objects;

namespace BestBusWay.WebUI.Controllers
{
    public class RouteController : Controller
    {
        IRouteRepository repository;
        EFDbContext db = new EFDbContext();

        public RouteController(IRouteRepository repo)
        {
            repository = repo;
        }

        // GET: Route
        public ViewResult Index()
        {
            var routes = db.Routes.Include(r => r.Bus)
                                  .Include(r => r.StartStation)
                                  .Include(r => r.EndStation)
                                  .Include(r => r.StartStation.City)
                                  .Include(r => r.EndStation)
                                  .Include(r => r.EndStation.City).ToList();
            var routeTime = db.RouteTimes.ToList();
            routes.ForEach(x => x.RouteTimes = routeTime.Where(p => p.RouteId == x.RouteId).ToList());
            return View(routes.ToList());
        }

        [HttpGet]
        public ViewResult Edit(int routeId)
        {
            Route route = repository.Routes.FirstOrDefault(r => r.RouteId == routeId);
            SelectList startStations = new SelectList(db.Stations, "StationId", "StName", route.StartStationId);
            SelectList endStations = new SelectList(db.Stations, "StationId", "StName", route.EndStationId);
            SelectList buses = new SelectList(db.Buses, "BusId", "Name", route.BusId);
            ViewBag.StartStations = startStations;
            ViewBag.EndStations = endStations;
            ViewBag.Buses = buses;

            return View(route);
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Route route)
        {
            if (!ModelState.IsValid)
            {
                return View(route);
            }
            else
            {
                repository.SaveRoute(route);
                TempData["message"] = string.Format("Изменения маршрута с  ID - \"{0}\" были сохранены", route.RouteId);
                return RedirectToAction("Index");
            }

        }


        [HttpGet]
        public ViewResult Create()
        {
            SelectList startStations = new SelectList(db.Stations, "StationId", "StName");
            SelectList endStations = new SelectList(db.Stations, "StationId", "StName");
            SelectList buses = new SelectList(db.Buses, "BusId", "Name");
            ViewBag.StartStations = startStations;
            ViewBag.EndStations = endStations;
            ViewBag.Buses = buses;
            return View("Edit", new Route());
        }

        [HttpPost]
        public ActionResult Delete(int routeId)
        {
            Route deleteRoute = repository.DeleteRoute(routeId);
            if (deleteRoute != null)
            {
                TempData["message"] = string.Format("Маршрут с ID - \"{0}\" был удален",
                    deleteRoute.RouteId);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AvailableRouteTimes()
        {
            var availableRouteTimes = db.RouteTimes
                               .Include(r => r.Route)
                               .Include(r => r.Route.Bus)
                               .Include(r => r.Route.StartStation)
                               .Include(r => r.Route.EndStation)
                               .Include(r => r.Route.StartStation.City)
                               .Include(r => r.Route.EndStation)
                               .Include(r => r.Route.EndStation.City).ToList();

            availableRouteTimes = availableRouteTimes.Where(r => r.TimeDeparture >= DateTime.Now).ToList();
            return View(availableRouteTimes.ToList());
        }

        [HttpPost]
        public ActionResult GetTicketByDate(int StartStationId, int EndStationId, DateTime TimeDeparture)
        {
            var availableRouteTimes = db.RouteTimes
                               .Include(r => r.Route)
                               .Include(r => r.Route.Bus)
                               .Include(r => r.Route.StartStation)
                               .Include(r => r.Route.EndStation)
                               .Include(r => r.Route.StartStation.City)
                               .Include(r => r.Route.EndStation)
                               .Include(r => r.Route.EndStation.City)
                               .Where(r => r.Route.StartStationId == StartStationId && r.Route.EndStationId == EndStationId &&
                               EntityFunctions.TruncateTime(r.TimeDeparture) == EntityFunctions.TruncateTime(TimeDeparture)).ToList();

            return View("AvailableRouteTimes", availableRouteTimes.ToList());
        }

        public ActionResult FormBuyTicket(int RouteTimeId)
        {
            var dataBuyTicket = db.RouteTimes
                               .Include(r => r.Route)
                               .Include(r => r.Route.Bus)
                               .Include(r => r.Route.StartStation)
                               .Include(r => r.Route.EndStation)
                               .Include(r => r.Route.StartStation.City)
                               .Include(r => r.Route.EndStation)
                               .Include(r => r.Route.EndStation.City)
                               .SingleOrDefault(r => r.RouteTimeId == RouteTimeId);
            return View("FormBuyTicket", dataBuyTicket);
        }

        [HttpPost]
        public ActionResult FormBuyTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return View(ticket);
            }
            else
            {
                repository.SaveTicket(ticket);
                
                TempData["message"] = string.Format("Покупка прошла успешно. Билет отправлен на Ваш Email {0}", ticket.TicketId);
                return RedirectToAction("Index", "Home");
            }

        }

    }
}