using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC2.Models
{
    public class JobDetailsCls
    {
        public int Jobid { get; set; }
        public int Company_id { get; set; }
        public string Jsskills { get; set; }
        public string Jsexperience { get; set; }
        public string Jobstatus { get; set; }
        public string Lastdate { get; set; }
        public string JobLocation { get; set; }
        public string ApplyMsg { get; set; }
    }
}