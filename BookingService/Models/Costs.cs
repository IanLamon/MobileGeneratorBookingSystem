using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingService.Models
{
    public class Costs
    {
        public int Id { get; set; }
        public decimal DieselCostPerLitre { get; set; }
        public decimal CostPerCustomer { get; set; }
        public decimal CostPerHour { get; set; }
    }
}