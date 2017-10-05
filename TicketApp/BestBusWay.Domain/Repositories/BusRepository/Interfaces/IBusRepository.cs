using System.Collections.Generic;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Repositories.BusRepository.Interfaces
{
    public interface IBusRepository
    {
        IEnumerable<Bus> Buses { get; }
        void SaveBus(Bus bus);
        Bus DeleteBus(int busId);
    }
}
