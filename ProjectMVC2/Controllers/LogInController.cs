using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using ProjectMVC2.Models;

namespace ProjectMVC2.Controllers
{
    public class LogInController : Controller
    {

        MVCProject2Entities dbobj = new MVCProject2Entities();
        // GET: LogIn
        public ActionResult LoginLoad()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult CompanyHome()
        {
            return View("~/Views/JobIn/JobLoad.cshtml");
        }
        public ActionResult LoginClick(LoginCls objcls)
        {

            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("lgsts", typeof(int));
                dbobj.sp_logcount(objcls.Luname,objcls.Lpassword, op);
                int val = Convert.ToInt32(op.Value.ToString());
                if (val == 1)
                {
                    var sessionID = dbobj.loginid(objcls.Luname, objcls.Lpassword).FirstOrDefault();
                    Session["sessionID"] = sessionID;
                    var logtypee = dbobj.sp_logtype(objcls.Luname, objcls.Lpassword).FirstOrDefault();
                    if (logtypee == "User")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (logtypee == "Company")
                    {
                        return RedirectToAction("CompanyHome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    objcls.Lmsg = "Invalid login";
                    return View("LoginLoad", objcls);
                }

            }

            return View("LoginLoad",objcls);
        }
    }
}