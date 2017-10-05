using BestBusWay.Domain.Repositories.StationRepository.Interfaces;
using System.Data.Entity;
using System.Web.Mvc;
using BestBusWay.Domain.Entities;
using System.Linq;
using System.Data;
using BestBusWay.Domain.Concrete;
using System.Collections.Generic;
using System;

namespace BestBusWay.WebUI.Controllers
{
    public class StationController : Controller
    {
        IStationRepository repository;
        EFDbContext db = new EFDbContext();

        public StationController(IStationRepository repo)
        {
            repository = repo;
        }

        // GET: Station
        public ViewResult Index()
        {         
                var stations = db.Stations.Include(s => s.City);
                return View(stations.ToList());
        }

        [HttpGet]
        public ViewResult Edit(int stationId)
        {    
            Station station = repository.Stations.FirstOrDefault(g => g.StationId == stationId);
            SelectList cities = new SelectList(db.Cities, "CityId", "CityName", station.CityId);
            ViewBag.Cities = cities;
            return View(station);  
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Station station)
        {
            if (!ModelState.IsValid)
            {
                return View(station);
            }
            else
            {
                repository.SaveStation(station);
                TempData["message"] = string.Format("Изменения станции с  ID - \"{0}\" были сохранены", station.StationId);
                return RedirectToAction("Index");
            }
            
        }


        [HttpGet]
        public ViewResult Create()
        {
            SelectList cities = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.Cities = cities;
            return View("Edit", new Station());
        } 

        [HttpPost]
        public ActionResult Delete(int stationId)
        {
            Station deleteStation = repository.DeleteStation(stationId);
            if (deleteStation != null)
            {
                TempData["message"] = string.Format("Станция \"{0}\" была удалена",
                    deleteStation.StName);
            }
            return RedirectToAction("Index");
        }
    }
}