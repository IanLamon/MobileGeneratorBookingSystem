using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Models
{
    public class StaffMember
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string PPSNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string BusinessUnit { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public bool Operator { get; set; }
        [Required]
        public bool Traffic { get; set; }
    }
}