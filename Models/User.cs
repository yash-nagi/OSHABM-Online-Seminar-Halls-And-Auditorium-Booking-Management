using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OSHABM_proj.Models
{
    public class User
    {
        [Required]
        public string UserID { get; set; }        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Photo { get; set; }
        public HttpPostedFileBase Imagepath { get; set; }
        
    }
}