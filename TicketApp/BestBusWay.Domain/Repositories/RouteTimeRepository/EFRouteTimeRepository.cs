using System.Collections.Generic;
using BestBusWay.Domain.Repositories;
using BestBusWay.Domain.Entities;
using BestBusWay.Domain.Repositories.RouteTimeRepository.Interfaces;
using System;
using System.Data.Entity;

namespace BestBusWay.Domain.Concrete
{
    public class EFRouteTimeRepository : IRouteTimeRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<RouteTime> RouteTimes
        {
            get { return context.RouteTimes; }
        }

        public void SaveRouteTime(RouteTime routeTime)
        {
            if (routeTime.RouteTimeId == 0)
            {
                context.RouteTimes.Add(routeTime);
            }
            else
            {
                RouteTime dbEntry = context.RouteTimes.Find(routeTime.RouteTimeId);
                if (dbEntry != null)
                {
                    dbEntry.TimeDeparture = routeTime.TimeDeparture;
                    dbEntry.TimeArrival = routeTime.TimeArrival;
                    //dbEntry.RouteId = 0;

                }
                // context.Entry(routeTime).State = EntityState.Modified; 
            }
            context.SaveChanges();
        }

        public RouteTime DeleteRouteTime(int RouteTimeId)
        {
            RouteTime dbEntry = context.RouteTimes.Find(RouteTimeId);
            if (dbEntry != null)
            {
                context.RouteTimes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

