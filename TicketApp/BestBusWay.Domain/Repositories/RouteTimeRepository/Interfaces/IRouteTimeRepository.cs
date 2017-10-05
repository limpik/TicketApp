using System.Collections.Generic;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Repositories.RouteTimeRepository.Interfaces
{
    public interface IRouteTimeRepository
    {
        IEnumerable<RouteTime> RouteTimes { get; }
        void SaveRouteTime(RouteTime routeTime);
        RouteTime DeleteRouteTime(int routeTimeId);
    }
}
