namespace BestBusWay.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        BusId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AmountPlaces = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BusId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        StartStationId = c.Int(nullable: false),
                        EndStationId = c.Int(nullable: false),
                        BusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.Buses", t => t.BusId)
                .ForeignKey("dbo.Stations", t => t.EndStationId)
                .ForeignKey("dbo.Stations", t => t.StartStationId)
                .Index(t => t.StartStationId)
                .Index(t => t.EndStationId)
                .Index(t => t.BusId);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StationId = c.Int(nullable: false, identity: true),
                        StName = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StationId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.RouteTimes",
                c => new
                    {
                        RouteTimeId = c.Int(nullable: false, identity: true),
                        TimeDeparture = c.DateTime(nullable: false),
                        TimeArrival = c.DateTime(nullable: false),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteTimeId)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        RouteTimeId = c.Int(nullable: false),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.RouteTimes", t => t.RouteTimeId, cascadeDelete: true)
                .Index(t => t.RouteTimeId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TicketId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        MName = c.String(),
                        LName = c.String(),
                        Email = c.String(),
                        NPassport = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Routes", "StartStationId", "dbo.Stations");
            DropForeignKey("dbo.Tickets", "RouteTimeId", "dbo.RouteTimes");
            DropForeignKey("dbo.RouteTimes", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Routes", "EndStationId", "dbo.Stations");
            DropForeignKey("dbo.Stations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Routes", "BusId", "dbo.Buses");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "RouteTimeId" });
            DropIndex("dbo.RouteTimes", new[] { "RouteId" });
            DropIndex("dbo.Stations", new[] { "CityId" });
            DropIndex("dbo.Routes", new[] { "BusId" });
            DropIndex("dbo.Routes", new[] { "EndStationId" });
            DropIndex("dbo.Routes", new[] { "StartStationId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Tickets");
            DropTable("dbo.RouteTimes");
            DropTable("dbo.Cities");
            DropTable("dbo.Stations");
            DropTable("dbo.Routes");
            DropTable("dbo.Buses");
        }
    }
}
