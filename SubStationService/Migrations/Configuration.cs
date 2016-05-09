namespace SubStationService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SubStationService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SubStationService.Models.SubStationServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SubStationService.Models.SubStationServiceContext context)
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

            context.SubStations.AddOrUpdate(x => x.Id,
                new SubStation() { Id = 1, Name = "Lucan South", Address = "Balgaddy Road, Lucan, Co. Dublin", Latitude = "53.3393371", Longitude = "-6.4254596", PeakLoadAmp = 14000, PeakLoadKw = 3200, TrafficManagement = false, NoOfCustomers = 10425, ContactFirstName = "Alex", ContactSurame = "Allen", ContactTelephone = "087 631 2759", ContactEmail = "ianlamon@outlook.com" },
                new SubStation() { Id = 2, Name = "Dundrum", Address = "Main Street, Dundrum, Dublin 14", Latitude = "53.2934796", Longitude = "-6.2478456", PeakLoadAmp = 9000, PeakLoadKw = 1750, TrafficManagement = true, NoOfCustomers = 12600, ContactFirstName = "Brian", ContactSurame = "Bryne", ContactTelephone = "087 631 2759", ContactEmail = "ianlamon@outlook.com" },
                new SubStation() { Id = 3, Name = "Malahide", Address = "Hanlons Lane, Malahide, Co. Dublin", Latitude = "53.4511465", Longitude = "-6.1626262", PeakLoadAmp = 7800, PeakLoadKw = 1490, TrafficManagement = true, NoOfCustomers = 7010, ContactFirstName = "Ciaran", ContactSurame = "Cullen", ContactTelephone = "087 631 2759", ContactEmail = "ianlamon@outlook.com" },
                new SubStation() { Id = 4, Name = "Bishopstown", Address = "Waterfall Road, Bishopstown, Co. Cork", Latitude = "51.8758527", Longitude = "-8.5279271", PeakLoadAmp = 11000, PeakLoadKw = 2700, TrafficManagement = false, NoOfCustomers = 9725, ContactFirstName = "Declan", ContactSurame = "Dunne", ContactTelephone = "087 631 2759", ContactEmail = "ianlamon@outlook.com" },
                new SubStation() { Id = 5, Name = "Patrickswell", Address = "Lisheen Park, Patrickswell, Limerick", Latitude = "52.5999999", Longitude = "-8.7175142", PeakLoadAmp = 4000, PeakLoadKw = 850, TrafficManagement = false, NoOfCustomers = 1025, ContactFirstName = "Ellen", ContactSurame = "Egan", ContactTelephone = "087 631 2759", ContactEmail = "ianlamon@outlook.com" },
                new SubStation() { Id = 6, Name = "Terryland", Address = "Dyke Road, Terryland, Galway", Latitude = "53.2815041", Longitude = "-9.0572348", PeakLoadAmp = 8000, PeakLoadKw = 2000, TrafficManagement = true, NoOfCustomers = 7600, ContactFirstName = "Frank", ContactSurame = "Faherty", ContactTelephone = "087 631 2759", ContactEmail = "ianlamon@outlook.com" },
                new SubStation() { Id = 7, Name = "Castlebar", Address = "Spencer Street, Castlebar, Co. Mayo", Latitude = "53.8537859", Longitude = "-9.2970957", PeakLoadAmp = 10000, PeakLoadKw = 2500, TrafficManagement = true, NoOfCustomers = 8425, ContactFirstName = "Grace", ContactSurame = "Green", ContactTelephone = "087 631 2759", ContactEmail = "ianlamon@outlook.com" },
                new SubStation() { Id = 8, Name = "Arklow", Address = "Coolgreaney Road, Arklow, Co. Wicklow", Latitude = "52.7977469", Longitude = "-6.1700558", PeakLoadAmp = 8025, PeakLoadKw = 1400, TrafficManagement = false, NoOfCustomers = 7325, ContactFirstName = "Harry", ContactSurame = "Hannon", ContactTelephone = "087 631 2759", ContactEmail = "ianlamon@outlook.com" },
                new SubStation() { Id = 9, Name = "Athlone East", Address = "Blackberry Lane, Athlone, Co. Westmeath", Latitude = "53.4275313", Longitude = "-7.9077182", PeakLoadAmp = 6600, PeakLoadKw = 1450, TrafficManagement = false, NoOfCustomers = 6900, ContactFirstName = "James", ContactSurame = "Jones", ContactTelephone = "087 631 2759", ContactEmail = "ianlamon@outlook.com" }
            );
        }
    }
}
