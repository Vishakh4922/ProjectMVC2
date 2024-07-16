using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC2.Models
{
    public class LoginCls
    {
        [Required(ErrorMessage ="Enter Username")]
        public string Luname { get; set; }
        [Required(ErrorMessage ="Enter Password")]
        public string Lpassword { get; set; }
        public string Lmsg { get; set; }
        public string ltype { get; set; }
        
    }
}