using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using H_project1.Models.AccessData;
using System.Web.Helpers;
using H_project1.Models.Utilitis;
using H_project1.Models.Repository;
using System.IO;
namespace H_project1.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        
        // GET: Home
        public ActionResult Index()
        {
            var IndexPageData = db.Page_index.OrderByDescending(c => c.id).Take(1).Single();
            return View(IndexPageData);
        }
        public ActionResult Login()
        {
            var LoginPageData = db.page_login.OrderByDescending(c => c.id).Take(1).Single();
            return View(LoginPageData);
        }
        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            try
            {
                username = username.Replace("'", "").Replace("=", "");
                password = Crypto.SHA256(password);
                var Admin = db.Admins.Where(c => c.username.Equals(username) && c.password.Equals(password));
                if (Admin.Count() ==1 )
                {
                    //Admin login
                    Session["AdminLogin"] = Admin.Single().id;
                    Session.Timeout = 90;
                    return Json(0, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    //User login
                    var User = db.Users.Where(c => c.Email.Equals(username) && c.password.Equals(password)).Single().id;
                    HttpCookie idLoginCookie = new HttpCookie("idlogin", User.ToString());
                    Response.Cookies["idlogin"].Secure = true;
                    Response.Cookies.Add(idLoginCookie);
                    return Json(1, JsonRequestBehavior.DenyGet);

                }
            }
            catch (Exception)
            {

                return Json(3, JsonRequestBehavior.DenyGet);
            }

        }
        [HttpPost]
        public ActionResult SignUp(User U, bool condition)
        {
            if (U.Fname == "" || U.lname == "" || U.Email == "" || U.password == "" || U.birthday == "10/24/1900" || U.gender == "" || condition == false)
             {
                 return Json(4, JsonRequestBehavior.DenyGet);
             }
            VerifyEmail v = new VerifyEmail();
            int validation = v.VEmail(U.Email);
            if (validation==0)
            {
                //Email is valid 
                Rep_user RU = new Rep_user();
                SHA256 Crypt=new SHA256 ();
                U.password = Crypt.DataSHA256(U.password);
                var signUp=RU.AddUser(U);
                var User = db.Users.Where(c => c.Email.Equals(U.Email) && c.password.Equals(U.password)).Single().id;
                string sp = Server.MapPath("\\Content\\User\\");
                Directory.CreateDirectory(sp + "\\" + User);
               //User login
                
                HttpCookie idLoginCookie = new HttpCookie("idlogin", User.ToString());
                Response.Cookies["idlogin"].Secure = true;
                Response.Cookies.Add(idLoginCookie);
                return Json(1, JsonRequestBehavior.DenyGet);

            }
            else if (validation==1)
            {
                //email exist in Database
                return Json(2, JsonRequestBehavior.DenyGet);

            }
            else
            {
                //email format is not valid 
                return Json(3, JsonRequestBehavior.DenyGet);
            }
           
        }
    }
}