using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace ProjectMVC2.Models
{
    
    public class UserInsert
    {
        [Required (ErrorMessage ="Enter the name")]
        public String Name { get; set; }
        [Range(18,60,ErrorMessage ="Enter the age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter the Address")]
        public String Address { get; set; }
        [Required(ErrorMessage = "Enter the Phone Number")]
        public String Phone { get; set; }
        [Required(ErrorMessage = "Enter the Mail Id")]
        public String Email { get; set; }

        public String Qualification { get; set; }
        public String Experience { get; set; }
        public String Skill { get; set; }
        public String Photo { get; set; }
        public String Resume { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        public string Uusername { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Upassword { get; set; }
        [Compare("Upassword", ErrorMessage = "Password Mismatch")]
        public string Uconfirmpassword { get; set; }
        public string logtype { get; set; }
        public string status { get; set; }

        public string UMsg { get; set; }
    }
}