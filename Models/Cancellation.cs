using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OSHABM_proj.Models
{
    public class Cancellation
    {
        [Required]
        public int Cancellation_No { get; set; }
       
        [Required]
        public string UserId { get; set;}
        
        [Required]
        public string Purpose { get; set; }
        [Required]
        public DateTime Date_of_Cancel { get; set; }
        [Required]
        public TimeSpan Time_of_Cancel { get;set; }
        
    }
}