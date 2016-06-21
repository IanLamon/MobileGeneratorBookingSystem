using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileGeneratorBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        //Booking Details
        [Required]
        [DisplayName("Booking Type")]
        public string BookingType { get; set; }

        [Required]
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartTime { get; set; }

        [Required]
        [DisplayName("Finish Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime FinishTime { get; set; }

        [Required]
        [DisplayName("WBS Number")]
        public string WBSNumber { get; set; }

        [DisplayName("Special Instructions")]
        public string SpecialInstructions { get; set; }

        [DisplayName("Booking Status")]
        public string BookingStatus { get; set; }

        //Costs
        [DisplayName("Customers Affected")]
        public int CustomersAffected { get; set; }

        [DisplayName("Cost per Customer")]
        public decimal CostPerCustomer { get; set; }

        [DisplayName("Cost per Hour")]
        public decimal CostPerHour { get; set; }

        [DisplayName("Generator Cost per Day")]
        public decimal CostOfGeneratorPerDay { get; set; }

        [DisplayName("Diesel Cost")]
        public decimal DieselCostPerLitre { get; set; }

        [DisplayName("Generator Diesel")]
        public decimal GeneratorDieselLitres { get; set; }

        [DisplayName("Truck Diesel")]
        public decimal TruckDieselLitres { get; set; }

        // Foreign Keys
        [DisplayName("Generator")]
        public int GeneratorId { get; set; }

        [DisplayName("Sub Station")]
        public int SubstationId { get; set; }

        [DisplayName("Operator 1")]
        public int Operator1Id { get; set; }

        [DisplayName("Operator 2")]
        public int Operator2Id { get; set; }

        [DisplayName("Traffic Manager")]
        public int? TrafficManagerId { get; set; }

        [DisplayName("Approver")]
        public int? ApproverId { get; set; }

        //Navigation property
        public virtual Generator Generator { get; set; }
        public virtual SubStation SubStation { get; set; }
        public virtual StaffMember Operator1 { get; set; }
        public virtual StaffMember Operator2 { get; set; }
        public virtual StaffMember TrafficManager { get; set; }
        public virtual StaffMember Approver { get; set; }
    }
}