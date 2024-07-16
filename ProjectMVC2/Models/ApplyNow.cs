using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC2.Models
{
    public class ApplyNow
    {
        public int AppId { get; set; }
        //public int CompId { get; set; }
        public int Userid { get; set; }
        public int Jobid { get; set; }
        public string Date { get; set; }
        public string AppStatus { get; set; }
        public string CV { get; set; }
        public string ApplyMsg { get; set; }
    }
}