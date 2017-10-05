using BestBusWay.Domain.Repositories.TicketRepository.Interfaces;
using System.Data.Entity;
using System.Web.Mvc;
using BestBusWay.Domain.Entities;
using System.Linq;
using System.Data;
using BestBusWay.Domain.Concrete;
using System.Collections.Generic;
using System;
using WebGrease.Css.Extensions;

namespace BestBusWay.WebUI.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket

        ITicketRepository repository;
        EFDbContext db = new EFDbContext();

        public TicketController(ITicketRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            var tickets = db.Tickets.Include(r => r.RouteTime)
                                    .Include(r => r.RouteTime.Route.StartStation)
                                    .Include(r => r.RouteTime.Route.EndStation)
                                    .Include(r => r.RouteTime.Route.StartStation.City)
                                    .Include(r => r.RouteTime.Route.EndStation.City);
            return View(tickets.ToList());
        }

        [HttpPost]
        public ActionResult Delete(int ticketId)
        {
            Ticket deleteTicket = repository.DeleteTicket(ticketId);
            if(deleteTicket != null)
            {
                TempData["message"] = string.Format("Билет с ID - \"{0}\" был удален", deleteTicket.TicketId);
            }
            return RedirectToAction("Index");
        }
    }
}