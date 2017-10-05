using System.Collections.Generic;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Repositories.StationRepository.Interfaces
{
    public interface IStationRepository
    {
        IEnumerable<Station> Stations { get; }
        void SaveStation(Station station);
        Station DeleteStation(int stationId);
    }
}
