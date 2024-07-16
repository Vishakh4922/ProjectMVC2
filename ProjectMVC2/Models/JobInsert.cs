using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace ProjectMVC2.Models
{
    public class JobInsert
    {
        [Required]
        public string Jtitle { get; set; }
        [Required]
        public string Jexperience { get; set; }
        [Required]
        public string Jskill { get; set; }
        [Required]
        public string Jvacancy { get; set; }
        [Required]
       
        public string Jdate { get; set; }
        public string Jstatus { get; set; }
        public string Jlocation { get; set; }
        public string Jmsg { get; set; }
    }
}