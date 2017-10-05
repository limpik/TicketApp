using System.Collections.Generic;
using BestBusWay.Domain.Repositories.CityRepository.Interfaces;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Concrete
{
    public class EFCityRepository : ICityRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<City> Cities
        {
            get { return context.Cities; }
        }

        public void SaveCity(City city)
        {
            if (city.CityId == 0)
                context.Cities.Add(city);
            else
            {
                City dbEntry = context.Cities.Find(city.CityId);
                if (dbEntry != null)
                {
                    dbEntry.CityName = city.CityName;
                    dbEntry.CountryName = city.CountryName;
                }
            }
            context.SaveChanges();
        }

        public City DeleteCity(int cityId)
        {
            City dbEntry = context.Cities.Find(cityId);
            if(dbEntry != null)
            {
                context.Cities.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}