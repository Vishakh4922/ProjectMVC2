using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC2.Models;
using System.IO;

namespace ProjectMVC2.Controllers
{
    public class UserInsController : Controller
    {

        MVCProject2Entities dbobj = new MVCProject2Entities();
        // GET: UserIns
        public ActionResult UserLoad()
        {
            return View();
        }
        public ActionResult UserClick(UserInsert clsobj, HttpPostedFileBase file1, HttpPostedFileBase file2)
        {
            if (ModelState.IsValid)
            {
                if (file1.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file1.FileName);
                    var s = Server.MapPath("~/photos");
                    string pa = Path.Combine(s, fname);
                    file1.SaveAs(pa);

                    var photopath = Path.Combine("~\\photos", fname);
                    clsobj.Photo = photopath;

                }
                if (file2.ContentLength > 0)
                {
                    string rname = Path.GetFileName(file2.FileName);
                    var s1 = Server.MapPath("~/resume");
                    string re = Path.Combine(s1, rname);
                    file2.SaveAs(re);

                    var resumepath = Path.Combine("~\\resume", rname);
                    clsobj.Resume = resumepath;
                }

                var getmaxid = dbobj.sp_logmaxid().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_userreg(regid, clsobj.Name, clsobj.Age, clsobj.Address, clsobj.Phone, clsobj.Email, clsobj.Qualification, clsobj.Experience, clsobj.Skill, clsobj.Photo, clsobj.Resume);
                dbobj.sp_logg(regid, clsobj.Uusername, clsobj.Upassword, "User");
                clsobj.UMsg = "User Inserted";
                return View("UserLoad", clsobj);
            }
            return View("UserLoad",clsobj);
        }
    }
}