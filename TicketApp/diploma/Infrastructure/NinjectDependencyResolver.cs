using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using BestBusWay.Domain.Entities;
using BestBusWay.Domain.Repositories;
using BestBusWay.Domain.Concrete;
using BestBusWay.Domain.Repositories.OrderRepository.Interfaces;
using BestBusWay.Domain.Repositories.CityRepository.Interfaces;
using BestBusWay.Domain.Repositories.StationRepository.Interfaces;
using BestBusWay.Domain.Repositories.BusRepository.Interfaces;
using BestBusWay.Domain.Repositories.RouteTimeRepository.Interfaces;
using BestBusWay.Domain.Repositories.RouteRepository.Interfaces;
using BestBusWay.Domain.Repositories.TicketRepository.Interfaces;

namespace BestBusWay.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Здесь размещаются привязки
            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();
            kernel.Bind<ICityRepository>().To<EFCityRepository>();
            kernel.Bind<IStationRepository>().To<EFStationRepository>();
            kernel.Bind<IBusRepository>().To<EFBusRepository>();
            kernel.Bind<IRouteTimeRepository>().To<EFRouteTimeRepository>();
            kernel.Bind<IRouteRepository>().To<EFRouteRepository>();
            kernel.Bind<ITicketRepository>().To<EFTicketRepository>();
            kernel.Bind<EFDbContext>().To<EFDbContext>();
        }
    }
}