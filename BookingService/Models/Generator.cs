using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Models
{
    public class Generator
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal CostPerDay { get; set; }
        [Required]
        public decimal GeneratorLitresPerHour { get; set; }
        [Required]
        public decimal TruckDieselLitresPerKm { get; set; }
        [Required]
        public int MaxAMP { get; set; }
        [Required]
        public int MaxKw { get; set; }
        [Required]
        public DateTime LastVehicleService { get; set; }
        [Required]
        public DateTime LastGeneratorMaintenance { get; set; }
        [Required]
        public DateTime LastMinorInspection { get; set; }
    }
}