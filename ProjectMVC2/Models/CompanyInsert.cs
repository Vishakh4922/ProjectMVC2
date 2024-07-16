using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC2.Models
{
    public class CompanyInsert
    {
        [Required(ErrorMessage = "Enter Name")]
        public string Cname { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Caddr { get; set; }
        [Required(ErrorMessage = "Enter Phone")]
        public string Cphone { get; set; }
        [Required(ErrorMessage = "Enter Email Address")]
        public string Cemail { get; set; }
        [Required(ErrorMessage = "Enter Website")]
        public string Cwebsite { get; set; }
        [Required(ErrorMessage = "Enter Location")]
        public string Clocation { get; set; }
        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }
        public string logtype{get;set;}
        public string status { get; set; }
        
        public string Msg { get; set; }
    }
}