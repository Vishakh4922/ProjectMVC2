using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC2.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace ProjectMVC2.Controllers
{
    public class JobSearchController : Controller
    {
        MVCProject2Entities dbobj = new MVCProject2Entities();
        // GET: JobSearch
        public ActionResult SearchLoad()
        {
            return View(GetData());
        }
        private JobSearch GetData()
        {
            var Joblist = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.Jobtabs.ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.Jobid = e.Jobid;
                jobcls.Company_id = e.Cid;
                jobcls.Jsskills = e.JSkills;
                jobcls.Jsexperience = e.JExperience;
                jobcls.Jobstatus = e.JStatus;
                jobcls.Lastdate = e.Date;
                jobcls.JobLocation = e.JLocation;
                Joblist.selectjob.Add(jobcls);

                var s = jobcls.Jsskills;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return Joblist;
        }

        public ActionResult SearchClick(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertsearch.Jsexperience))
            {
                qry += " and JExperience like '%" + clsobj.insertsearch.Jsexperience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertsearch.Jsskills))
            {
                qry += " and JSkills like '%" + clsobj.insertsearch.Jsskills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertsearch.JobLocation))
            {
                qry += " and JLocation like '%" + clsobj.insertsearch.JobLocation + "%'";
            }
            return View("SearchLoad", getdata1(clsobj, qry));
        }

        private JobSearch getdata1(JobSearch clsobj, string qry)
        {
            using (var con = new SqlConnection(@"server=GOWTHAMPC\SQLEXPRESS;database=MVCProject2;integrated security=true")) //(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_searchjobs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist2 = new JobSearch();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.Company_id = Convert.ToInt32(dr["Cid"].ToString());
                    jobcls.Jsskills = dr["JSkills"].ToString();
                    jobcls.Jsexperience = dr["JExperience"].ToString();
                    jobcls.JobLocation = dr["JLocation"].ToString();
                    jobcls.Jobstatus = dr["JStatus"].ToString();
                    jobcls.Lastdate = dr["Date"].ToString();

                    joblist2.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist2;

            }
        }

    }
}

  