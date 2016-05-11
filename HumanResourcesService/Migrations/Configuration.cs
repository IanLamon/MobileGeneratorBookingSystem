namespace HumanResourcesService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HumanResourcesService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HumanResourcesService.Models.HumanResourcesServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HumanResourcesService.Models.HumanResourcesServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.StaffMembers.AddOrUpdate(x => x.Id,
                new StaffMember() { Id = 1, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true },
                new StaffMember() { Id = 2, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true },
                new StaffMember() { Id = 3, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true },
                new StaffMember() { Id = 4, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true },
                new StaffMember() { Id = 5, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true },
                new StaffMember() { Id = 6, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true },
                new StaffMember() { Id = 7, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true },
                new StaffMember() { Id = 8, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true },
                new StaffMember() { Id = 9, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true },
                new StaffMember() { Id = 10, FirstName = "Ian", Surname = "Lamon", DOB = new DateTime(1979, 08, 03, 0, 0, 0), PPSNumber = "7182298K", Email = "ian.lamon@esb.ie", Telephone = "0876312759", BusinessUnit = "ESB Networks", Role = "Technician", Level = 2, StartDate = new DateTime(2015, 06, 02, 0, 0, 0), Operator = true, Traffic = true }
            );
        }
    }
}