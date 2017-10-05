using System.Collections.Generic;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Repositories.CityRepository.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
        void SaveCity(City city);
        City DeleteCity(int cityId);
    }
}
