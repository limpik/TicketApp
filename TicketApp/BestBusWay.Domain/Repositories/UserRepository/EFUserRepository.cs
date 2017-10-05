using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestBusWay.Domain.Entities;
using BestBusWay.Domain.Repositories.UserRepository.Interfaces;

namespace BestBusWay.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
           get { return context.Users;  }
        }
    }
}
