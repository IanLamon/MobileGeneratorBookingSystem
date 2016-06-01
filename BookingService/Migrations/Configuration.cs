namespace BookingService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookingService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookingService.Models.BookingServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookingService.Models.BookingServiceContext context)
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

            context.Bookings.AddOrUpdate(x => x.Id,
                new Booking() { Id = 1, BookingType = "Standard", StartTime = new DateTime(2016, 08, 07, 09, 0, 0), FinishTime = new DateTime(2016, 08, 07, 16, 0, 0), WBSNumber = "DN12345", SpecialInstructions = "", BookingStatus = "To Be Approved", CustomersAffected = 10425, CostPerCustomer = 8.00m, CostPerHour = 10.00m, CostOfGeneratorPerDay = 2500.00m, DieselCostPerLitre = 1.16m, GeneratorDieselLitres = 100.00m, TruckDieselLitres = 25.00m, GeneratorId = 1, SubstationId = 1, Operator1Id = 1, Operator2Id = 2, TrafficManagerId = 3, ApprovedById = 4 },
                new Booking() { Id = 1, BookingType = "Standard", StartTime = new DateTime(2016, 12, 07, 09, 0, 0), FinishTime = new DateTime(2016, 12, 07, 16, 0, 0), WBSNumber = "DN12346", SpecialInstructions = "", BookingStatus = "To Be Approved", CustomersAffected = 12600, CostPerCustomer = 8.00m, CostPerHour = 10.00m, CostOfGeneratorPerDay = 2500.00m, DieselCostPerLitre = 1.16m, GeneratorDieselLitres = 100.00m, TruckDieselLitres = 25.00m, GeneratorId = 2, SubstationId = 2, Operator1Id = 7, Operator2Id = 12, TrafficManagerId = 4, ApprovedById = 1 },
                new Booking() { Id = 1, BookingType = "Service", StartTime = new DateTime(2016, 13, 07, 09, 0, 0), FinishTime = new DateTime(2016, 13, 07, 16, 0, 0), WBSNumber = "DN12347", SpecialInstructions = "", BookingStatus = "To Be Approved", CustomersAffected = 7010, CostPerCustomer = 8.00m, CostPerHour = 10.00m, CostOfGeneratorPerDay = 2500.00m, DieselCostPerLitre = 1.16m, GeneratorDieselLitres = 100.00m, TruckDieselLitres = 25.00m, GeneratorId = 3, SubstationId = 3, Operator1Id = 8, Operator2Id = 11, TrafficManagerId = 5, ApprovedById = 2 },
                new Booking() { Id = 1, BookingType = "Standard", StartTime = new DateTime(2016, 13, 07, 09, 0, 0), FinishTime = new DateTime(2016, 13, 07, 16, 0, 0), WBSNumber = "DN12348", SpecialInstructions = "", BookingStatus = "Approved", CustomersAffected = 9725, CostPerCustomer = 8.00m, CostPerHour = 10.00m, CostOfGeneratorPerDay = 2500.00m, DieselCostPerLitre = 1.16m, GeneratorDieselLitres = 100.00m, TruckDieselLitres = 25.00m, GeneratorId = 1, SubstationId = 4, Operator1Id = 9, Operator2Id = 10, TrafficManagerId = 0, ApprovedById = 2 },
                new Booking() { Id = 1, BookingType = "Provisional", StartTime = new DateTime(2016, 21, 07, 09, 0, 0), FinishTime = new DateTime(2016, 21, 07, 16, 0, 0), WBSNumber = "DN12349", SpecialInstructions = "", BookingStatus = "To Be Confirmed", CustomersAffected = 1025, CostPerCustomer = 8.00m, CostPerHour = 10.00m, CostOfGeneratorPerDay = 2500.00m, DieselCostPerLitre = 1.16m, GeneratorDieselLitres = 100.00m, TruckDieselLitres = 25.00m, GeneratorId = 3, SubstationId = 5, Operator1Id = 14, Operator2Id = 15, TrafficManagerId = 0, ApprovedById = 1 }
                );
        }
    }
}
