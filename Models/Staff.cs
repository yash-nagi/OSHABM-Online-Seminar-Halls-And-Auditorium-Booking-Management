using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OSHABM_proj.Models
{
    public class Staff
    {
        [Required]
        public string StaffID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] public string EmailID { get; set; }
        [Required]
        public string Password { get; set; }

        [Required] public long Mobile { get; set; }
    }
}