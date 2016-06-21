using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MobileGeneratorBooking.Models
{
    public class Costs
    {
        public int Id { get; set; }

        [DisplayName("Diesel Cost")]
        public decimal DieselCostPerLitre { get; set; }

        [DisplayName("Revenue per Outage")]
        public decimal CostPerCustomer { get; set; }

        [DisplayName("Revenue per Hour")]
        public decimal CostPerHour { get; set; }
    }
}