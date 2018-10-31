using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H_project1.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        public ActionResult Index()
        {
            if (Session["AdminLogin"] == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}