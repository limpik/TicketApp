using System.Collections.Generic;
using BestBusWay.Domain.Repositories.TicketRepository.Interfaces;
using BestBusWay.Domain.Entities;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using System;

namespace BestBusWay.Domain.Concrete
{
    public class EFTicketRepository : ITicketRepository
    {
        EFDbContext context = new EFDbContext();
        
        public IEnumerable<Ticket> Tickets
        {
            get { return context.Tickets; }
        }

        public Ticket DeleteTicket(int ticketId)
        {
            Ticket dbEntry = context.Tickets.Find(ticketId);
            if(dbEntry != null)
            {
                context.Tickets.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    
    }

    
}
