using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OSHABM_proj.Models
{
    public class Feedback
    {
       
        [Required]
        public string UserID { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Purpose { get; set; }
        [Required]
        public DateTime Date_of_Submission { get; set; }
        [Required]
        public TimeSpan Time_of_Submission { get; set; }


    }
}