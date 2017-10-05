using BestBusWay.Domain.Entities;
using System.Data.Entity;
using BestBusWay.Domain.Context.Mapping;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BestBusWay.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<RouteTime> RouteTimes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = false;
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Configurations.Add(new RouteMapping());
            modelBuilder.Configurations.Add(new RouteTimeMapping());
        }
    }
}
