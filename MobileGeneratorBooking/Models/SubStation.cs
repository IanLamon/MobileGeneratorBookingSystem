using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileGeneratorBooking.Models
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
        [DisplayName("Peak Load (Amp)")]
        public int PeakLoadAmp { get; set; }

        [Required]
        [DisplayName("Peak Load (Kw)")]
        public int PeakLoadKw { get; set; }

        [Required]
        [DisplayName("Traffic Management Required")]
        public bool TrafficManagement { get; set; }

        [Required]
        [DisplayName("Customers Affected")]
        public int NoOfCustomers { get; set; }

        [Required]
        [DisplayName("Contact First Name")]
        public string ContactFirstName { get; set; }

        [Required]
        [DisplayName("Contact Surname")]
        public string ContactSurame { get; set; }

        [Required]
        [DisplayName("Contact Telephone")]
        public string ContactTelephone { get; set; }

        [Required]
        [DisplayName("Contact Email")]
        public string ContactEmail { get; set; }
    }
}