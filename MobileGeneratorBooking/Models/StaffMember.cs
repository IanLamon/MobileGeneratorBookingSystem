using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileGeneratorBooking.Models
{
    public class StaffMember
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [DisplayName("PPS Number")]
        public string PPSNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        [DisplayName("Business Unit")]
        public string BusinessUnit { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        public bool Operator { get; set; }

        [Required]
        [DisplayName("Traffic Manager")]
        public bool Traffic { get; set; }
    }
}