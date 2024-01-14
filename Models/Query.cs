using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OSHABM_proj.Models
{
    public class Query
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailID { get; set;}
        [Required]
        public long Phone { get;set;}
        [Required]
        public DateTime Event_Date { get;set;}
        [Required]
        public string Event_Type { get;set;}
        
    }
}