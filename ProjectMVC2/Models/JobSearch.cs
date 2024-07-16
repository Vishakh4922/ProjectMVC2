using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC2.Models
{
    public class JobSearch
    {

        public JobSearch()
        {
            selectjob = new List<jsearch>();
            insertsearch = new jsearch();
        }
        public jsearch insertsearch { get; set; }
        public List<jsearch> selectjob { get; set; }
    }
    public class jsearch
    {
        public int Jobid { get; set; }
        public int Company_id { get; set; }

        public string Jsskills { get; set; }

        public string Jsexperience { get; set; }
        public string Jobstatus { get; set; }
        public string Lastdate { get; set; }
        public string JobLocation { get; set; }
    }

}