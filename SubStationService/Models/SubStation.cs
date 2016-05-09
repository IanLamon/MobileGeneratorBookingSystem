using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SubStationService.Models
{
    public class SubStation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public int PeakLoadAmp { get; set; }
        [Required]
        public int PeakLoadKw { get; set; }
        [Required]
        public bool TrafficManagement { get; set; }
        [Required]
        public int NoOfCustomers { get; set; }
        [Required]
        public string ContactFirstName { get; set; }
        [Required]
        public string ContactSurame { get; set; }
        [Required]
        public string ContactTelephone { get; set; }
        [Required]
        public string ContactEmail { get; set; }
    }
}