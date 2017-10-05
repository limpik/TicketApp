using System.Collections.Generic;
using BestBusWay.Domain.Repositories.BusRepository.Interfaces;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Concrete
{
    public class EFBusRepository : IBusRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Bus> Buses
        {
            get { return context.Buses; }
        }

        public void SaveBus(Bus bus)
        {
            if(bus.BusId == 0)
            {
                context.Buses.Add(bus);
            }
            else
            {
                Bus dbEntry = context.Buses.Find(bus.BusId);
                if(dbEntry != null)
                {
                    dbEntry.Name = bus.Name;
                    dbEntry.AmountPlaces = bus.AmountPlaces;
                }
            }
            context.SaveChanges();
        }

        public Bus DeleteBus(int busId)
        {
            Bus dbEntry = context.Buses.Find(busId);
            if(dbEntry != null)
            {
                context.Buses.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
