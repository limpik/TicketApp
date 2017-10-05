using System.Collections.Generic;
using BestBusWay.Domain.Repositories;
using BestBusWay.Domain.Entities;
using BestBusWay.Domain.Repositories.OrderRepository.Interfaces;
using System;

namespace BestBusWay.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void SaveOrder(Order order)
        {
            if(order.OrderId == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.Find(order.OrderId);
                if(dbEntry != null)
                {
                    dbEntry.OrderDate = order.OrderDate;
                    dbEntry.TicketId = order.TicketId;
                }
            }
            context.SaveChanges();
        }
        
    }
}
