using System.Collections.Generic;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Repositories.OrderRepository.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
