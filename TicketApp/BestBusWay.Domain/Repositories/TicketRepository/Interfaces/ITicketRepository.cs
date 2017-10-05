using System.Collections.Generic;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Repositories.TicketRepository.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> Tickets { get; }
        
        Ticket DeleteTicket(int ticketId);
    }
}
