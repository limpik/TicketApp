using System;
using System.Collections.Generic;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Repositories.UserRepository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
    }
}
