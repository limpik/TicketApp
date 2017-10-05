using System.Collections.Generic;
using BestBusWay.Domain.Repositories.StationRepository.Interfaces;
using BestBusWay.Domain.Entities;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using System;

namespace BestBusWay.Domain.Concrete
{
    public class EFStationRepository : IStationRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Station> Stations
        {
            get { return context.Stations; }
        }

        public void SaveStation(Station station)
        {
            if(station.StationId == 0)
            {
                context.Stations.Add(station);
            }
            else
            {
                context.Entry(station).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Station DeleteStation(int stationId)
        {
            Station dbEntry = context.Stations.Find(stationId);
            if(dbEntry != null)
            {
                context.Stations.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
