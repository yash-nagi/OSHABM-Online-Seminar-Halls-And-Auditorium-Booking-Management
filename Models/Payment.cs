using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OSHABM_proj.Models
{
    public class Payment
    {
        [Required]
        public int PayID { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string AuditID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public string Payment_Type { get; set; }
        [Required]
        public DateTime Date_of_Booking { get; set; }
        [Required]
        public TimeSpan Time_of_Booking { get; set;}
    }
}