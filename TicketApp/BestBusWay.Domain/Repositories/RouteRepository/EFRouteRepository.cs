using System.Collections.Generic;
using BestBusWay.Domain.Repositories;
using BestBusWay.Domain.Entities;
using BestBusWay.Domain.Repositories.RouteRepository.Interfaces;
using System;
using System.Data.Entity;

namespace BestBusWay.Domain.Concrete
{
    public class EFRouteRepository : IRouteRepository
    {
       
            EFDbContext context = new EFDbContext();

            public IEnumerable<Route> Routes
            {
                get { return context.Routes; }
            }

            public void SaveRoute(Route route)
            {
                if (route.RouteId == 0)
                {
                    context.Routes.Add(route);
                }
                else
                {
                    context.Entry(route).State = EntityState.Modified; 
                }
                context.SaveChanges();
            }

            public void SaveTicket(Ticket ticket)
            {
                if (ticket.TicketId == 0)
                    context.Tickets.Add(ticket);
                else
                {
                    Ticket dbEntry = context.Tickets.Find(ticket.TicketId);
                    if (dbEntry != null)
                    {
                        dbEntry.FullName = ticket.FullName;
                        dbEntry.Email = ticket.Email;
                        dbEntry.Date = DateTime.Now;
                        dbEntry.RouteTimeId = ticket.RouteTimeId;                        
                    }
                }
                 context.SaveChanges();
        }

        public Route DeleteRoute(int routeId)
            {
                Route dbEntry = context.Routes.Find(routeId);
                if (dbEntry != null)
                {
                    context.Routes.Remove(dbEntry);
                    context.SaveChanges();
                }
                return dbEntry;
            }
        }
    }

