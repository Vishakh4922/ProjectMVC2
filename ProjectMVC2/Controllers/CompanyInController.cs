using ProjectMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ProjectMVC2.Controllers
{
    public class CompanyInController : Controller
    {
        MVCProject2Entities dbobj = new MVCProject2Entities();
        // GET: CompanyIn
        public ActionResult CompanyLoad()
        {
            return View();
        }

        public ActionResult CompanyClick(CompanyInsert clsobj)
        {

            if (ModelState.IsValid)
            {
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
                dbobj.sp_company(regid, clsobj.Cname, clsobj.Caddr, clsobj.Cphone, clsobj.Cemail, clsobj.Cwebsite, clsobj.Clocation);
                dbobj.sp_logg (regid, clsobj.Username, clsobj.Password, "Company");
                clsobj.Msg = "Inserted";
                return View("CompanyLoad", clsobj);
            }
            return View("CompanyLoad", clsobj);

        }
    }
}
