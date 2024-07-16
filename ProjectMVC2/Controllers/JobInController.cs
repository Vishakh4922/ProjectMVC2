using ProjectMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ProjectMVC2.Controllers
{
   
    public class JobInController : Controller
    {
        MVCProject2Entities dbobj = new MVCProject2Entities();
        // GET: JobIn
        public ActionResult JobLoad()
        {
            return View();
        }
        public ActionResult JobClick(JobInsert clsobj)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    //clsobj.Jdate = DateTime.Now.AddDays(10);
                    clsobj.Jstatus = "Available";

                    if (Session["sessionID"] != null)
                    {
                        int sessionID = Convert.ToInt32(Session["sessionID"]);
                        dbobj.sp_jobadd(sessionID, clsobj.Jtitle, clsobj.Jexperience, clsobj.Jskill, clsobj.Jvacancy, clsobj.Jdate, clsobj.Jstatus, clsobj.Jlocation);
                        clsobj.Jmsg = "Job added successfully!";
                    }
                    else
                    {
                        clsobj.Jmsg = "Session expired. Please log in again.";
                    }
                }
                catch (Exception ex)
                {
                    clsobj.Jmsg = "Error adding job: " + ex.Message;
                    if (ex.InnerException != null)
                    {
                        clsobj.Jmsg += " Inner Exception: " + ex.InnerException.Message;
                    }
                    // Log the exception for further investigation
                    // Example: logger.Error("Error adding job", ex);
                }

            }
            else
            {
                clsobj.Jmsg = "Invalid";
            }
            return View("JobLoad",clsobj);
        }
    }
}