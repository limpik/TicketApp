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

namespace diploma.Controllers
{
    public class HomeController : Controller
    {
        private EFDbContext context = new EFDbContext();

        public ActionResult Index()
        {
            return View(context.Stations.Include(x=> x.City).ToList());
        }

        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}