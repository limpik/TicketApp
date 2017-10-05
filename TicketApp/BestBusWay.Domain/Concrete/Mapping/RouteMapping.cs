using BestBusWay.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BestBusWay.Domain.Context.Mapping
{
    public class RouteMapping : EntityTypeConfiguration<Route>
    {
        public RouteMapping()
        {
            HasKey(p => p.RouteId);

            HasRequired(x => x.Bus)
                .WithMany(x => x.Routes)
                .HasForeignKey(x => x.BusId)
                 .WillCascadeOnDelete(false); ;

            HasRequired(x => x.StartStation)
                .WithMany(x => x.StartStations)
                .HasForeignKey(x => x.StartStationId)
                 .WillCascadeOnDelete(false); ;

            /* HasRequired(x => x.StartStation)
             .WithMany(x => x.StartStations)
             .HasForeignKey(x => x.StartStationId)
             .WillCascadeOnDelete(false);
 */
            HasRequired(x => x.EndStation)
                 .WithMany(x => x.EndStations)
                 .HasForeignKey(x => x.EndStationId)
                 .WillCascadeOnDelete(false);
            

            /*    Property(x => x.RouteId).HasColumnName("RouteId");
                Property(x => x.BusId).HasColumnName("BusId");
                Property(x => x.StartStationId).HasColumnName("StartStationId");
                Property(x => x.EndStationId).HasColumnName("EndStationId"); */

        }
}
}
