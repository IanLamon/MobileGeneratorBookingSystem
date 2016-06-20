using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileGeneratorBooking.Models
{
    public class Generator
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Cost per Day")]
        public decimal CostPerDay { get; set; }

        [Required]
        [DisplayName("Diesel Consumption")]
        public decimal GeneratorLitresPerHour { get; set; }

        [Required]
        [DisplayName("Truck Diesel per KM")]
        public decimal TruckDieselLitresPerKm { get; set; }

        [Required]
        [DisplayName("Max AMP")]
        public int MaxAMP { get; set; }

        [Required]
        [DisplayName("Max Kw")]
        public int MaxKw { get; set; }
        
        [Required]
        [DisplayName("Last Vehicle Service")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime LastVehicleService { get; set; }

        [Required]
        [DisplayName("Last Generator Maintenance")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime LastGeneratorMaintenance { get; set; }

        [Required]
        [DisplayName("Last Minor Inspection")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime LastMinorInspection { get; set; }
    }
}