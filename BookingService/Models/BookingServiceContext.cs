using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingService.Models
{
    public class BookingServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BookingServiceContext() : base("name=BookingServiceContext")
        {
        }

        public System.Data.Entity.DbSet<BookingService.Models.Booking> Bookings { get; set; }

        public System.Data.Entity.DbSet<BookingService.Models.Generator> Generators { get; set; }

        public System.Data.Entity.DbSet<BookingService.Models.StaffMember> StaffMembers { get; set; }

        public System.Data.Entity.DbSet<BookingService.Models.SubStation> SubStations { get; set; }

        public System.Data.Entity.DbSet<BookingService.Models.Costs> Costs { get; set; }
    
    }
}
