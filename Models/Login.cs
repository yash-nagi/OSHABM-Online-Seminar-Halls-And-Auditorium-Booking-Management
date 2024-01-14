 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace OSHABM_proj.Models
{
    public class Login
    {
        [Required(ErrorMessage="Email Id is required")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Please enter valid email id")]
        public string EmailID { get; set; }
       
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


    }
}