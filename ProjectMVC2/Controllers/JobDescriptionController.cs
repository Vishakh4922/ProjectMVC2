using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjectMVC2.Models;
using System.Data;
using System.IO;
using System.Configuration;

namespace ProjectMVC2.Controllers
{

    public class JobDescriptionController : Controller
    {
        MVCProject2Entities dbobj = new MVCProject2Entities();

        // GET: JobDescription
        public ActionResult JobDetails(int cid, int jid)
        {
            Session["cid"] = cid;
            Session["jid"] = jid;
            
            int jid1 = Convert.ToInt32(Session["jid"]);
            int cid1 = Convert.ToInt32(Session["cid"]);
            var job = dbobj.Jobtabs.FirstOrDefault(j => j.Jobid == jid1 && j.Cid == cid1);
            if (job == null)
            {
                return HttpNotFound();
            }

            var jobDetail = new JobDetailsCls
            {
                Jobid = job.Jobid,
                Company_id = job.Cid,
                Jsskills = job.JSkills,
                Jsexperience = job.JExperience,
                Jobstatus = job.JStatus,
                Lastdate = job.Date,
                JobLocation = job.JLocation
            };
            return View(jobDetail);
        }

        [HttpPost]
        public ActionResult ApplyClick(ApplyNow obj, HttpPostedFileBase file)
        {

            obj.Jobid = Convert.ToInt32(Session["jid"]);
            int userId = Convert.ToInt32(Session["sessionID"]);

            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/resume"), fileName);
                file.SaveAs(path);

                string resumepath = Path.Combine("~\\resume", fileName);
                obj.CV = resumepath;

                // Set AppStatus to a default value
                obj.AppStatus = "Pending";
   
                dbobj.sp_appdata(obj.Userid = userId, obj.Jobid, obj.CV, obj.Date = DateTime.Now.ToString(), obj.AppStatus);
                obj.ApplyMsg = "Applied Successfully";
                ViewBag.Message = obj.ApplyMsg;
            }
            else
            {
                ViewBag.Message = "Please upload a valid CV.";
            }

            return View();
        }

    }
}