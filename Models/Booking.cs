using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OSHABM_proj.Models
{
    public class Booking
    {
        [Required] public string EmailID { get; set; }
        [Required]
        public string BookingId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string AuditId { get; set; }
        [Required]
        public DateTime Date_of_Booking { get; set;}
        [Required]
        public TimeSpan Time_of_Booking { get; set; }

        [Required]
        public string PayId { get; set; }
    }
}
