namespace HumanResourcesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StaffMembers");
        }
    }
}
