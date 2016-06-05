namespace BookingService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingType = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                        WBSNumber = c.String(nullable: false),
                        SpecialInstructions = c.String(),
                        BookingStatus = c.String(),
                        CustomersAffected = c.Int(nullable: false),
                        CostPerCustomer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostOfGeneratorPerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DieselCostPerLitre = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GeneratorDieselLitres = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TruckDieselLitres = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GeneratorId = c.Int(nullable: false),
                        SubstationId = c.Int(nullable: false),
                        Operator1Id = c.Int(nullable: false),
                        Operator2Id = c.Int(nullable: false),
                        TrafficManagerId = c.Int(),
                        ApproverId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StaffMembers", t => t.ApproverId)
                .ForeignKey("dbo.Generators", t => t.GeneratorId, cascadeDelete: false)
                .ForeignKey("dbo.StaffMembers", t => t.Operator1Id, cascadeDelete: false)
                .ForeignKey("dbo.StaffMembers", t => t.Operator2Id, cascadeDelete: false)
                .ForeignKey("dbo.SubStations", t => t.SubstationId, cascadeDelete: false)
                .ForeignKey("dbo.StaffMembers", t => t.TrafficManagerId)
                .Index(t => t.GeneratorId)
                .Index(t => t.SubstationId)
                .Index(t => t.Operator1Id)
                .Index(t => t.Operator2Id)
                .Index(t => t.TrafficManagerId)
                .Index(t => t.ApproverId);
            
            CreateTable(
                "dbo.StaffMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        PPSNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Telephone = c.String(nullable: false),
                        BusinessUnit = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Operator = c.Boolean(nullable: false),
                        Traffic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Generators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CostPerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GeneratorLitresPerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TruckDieselLitresPerKm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxAMP = c.Int(nullable: false),
                        MaxKw = c.Int(nullable: false),
                        LastVehicleService = c.DateTime(nullable: false),
                        LastGeneratorMaintenance = c.DateTime(nullable: false),
                        LastMinorInspection = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Latitude = c.String(nullable: false),
                        Longitude = c.String(nullable: false),
                        PeakLoadAmp = c.Int(nullable: false),
                        PeakLoadKw = c.Int(nullable: false),
                        TrafficManagement = c.Boolean(nullable: false),
                        NoOfCustomers = c.Int(nullable: false),
                        ContactFirstName = c.String(nullable: false),
                        ContactSurame = c.String(nullable: false),
                        ContactTelephone = c.String(nullable: false),
                        ContactEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Costs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DieselCostPerLitre = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerCustomer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "TrafficManagerId", "dbo.StaffMembers");
            DropForeignKey("dbo.Bookings", "SubstationId", "dbo.SubStations");
            DropForeignKey("dbo.Bookings", "Operator2Id", "dbo.StaffMembers");
            DropForeignKey("dbo.Bookings", "Operator1Id", "dbo.StaffMembers");
            DropForeignKey("dbo.Bookings", "GeneratorId", "dbo.Generators");
            DropForeignKey("dbo.Bookings", "ApproverId", "dbo.StaffMembers");
            DropIndex("dbo.Bookings", new[] { "ApproverId" });
            DropIndex("dbo.Bookings", new[] { "TrafficManagerId" });
            DropIndex("dbo.Bookings", new[] { "Operator2Id" });
            DropIndex("dbo.Bookings", new[] { "Operator1Id" });
            DropIndex("dbo.Bookings", new[] { "SubstationId" });
            DropIndex("dbo.Bookings", new[] { "GeneratorId" });
            DropTable("dbo.Costs");
            DropTable("dbo.SubStations");
            DropTable("dbo.Generators");
            DropTable("dbo.StaffMembers");
            DropTable("dbo.Bookings");
        }
    }
}
