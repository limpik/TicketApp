using BestBusWay.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BestBusWay.Domain.Context.Mapping
{
    public class RouteTimeMapping : EntityTypeConfiguration<RouteTime>
    {
        public RouteTimeMapping()
        {
            HasKey(p => p.RouteTimeId);

            HasRequired(x => x.Route)
                .WithMany(x => x.RouteTimes)
                .HasForeignKey(x => x.RouteId);

          //  Property(x => x.RouteTimeId).HasColumnName("routeTimeId");
          //  Property(x => x.RouteId).HasColumnName("routeId");
           // Property(x => x.TimeDeparture).HasColumnName("timeDeparture");
           // Property(x => x.TimeArrival).HasColumnName("timeArrival");
        }
    }
}