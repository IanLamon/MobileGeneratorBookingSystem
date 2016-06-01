using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Models
{
    public class Booking
    {
        public int Id { get; set; }
        //Booking Details
        [Required]
        public string BookingType { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime FinishTime { get; set; }
        [Required]
        public string WBSNumber { get; set; }
        public string SpecialInstructions { get; set; }
        public string BookingStatus { get; set; }
        //Costs
        public int CustomersAffected { get; set; }
        public decimal CostPerCustomer { get; set; }
        public decimal CostPerHour { get; set; }
        public decimal CostOfGeneratorPerDay { get; set; }
        public decimal DieselCostPerLitre { get; set; }
        public decimal GeneratorDieselLitres { get; set; }
        public decimal TruckDieselLitres { get; set; }
        // Foreign Keys
        public int GeneratorId { get; set; }
        public int SubstationId { get; set; }
        public int Operator1Id { get; set; }
        public int Operator2Id { get; set; }
        public int TrafficManagerId { get; set; }
        public int ApprovedById { get; set; }
        //Navigation property
        public Generator Generator { get; set; }
        public SubStation SubStation { get; set; }
        public StaffMember Operator1 { get; set; }
        public StaffMember Operator2 { get; set; }
        public StaffMember TrafficManager { get; set; }
        public StaffMember Approver { get; set; }
    }
}