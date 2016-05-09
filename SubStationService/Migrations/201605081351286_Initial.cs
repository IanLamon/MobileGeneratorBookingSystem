namespace SubStationService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubStations");
        }
    }
}
