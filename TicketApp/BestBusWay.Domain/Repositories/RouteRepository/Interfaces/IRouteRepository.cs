using System.Collections.Generic;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Repositories.RouteRepository.Interfaces
{
    public interface IRouteRepository
    {
        IEnumerable<Route> Routes { get; }
        void SaveRoute(Route route);
        void SaveTicket(Ticket ticket);
        Route DeleteRoute(int routeId);
    }
}
