using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using H_project1.Models.AccessData;
using System.Web.Helpers;
using H_project1.Models.Utilitis;
using H_project1.Models.Repository;
using H_project1.Models.ViewModel;

namespace H_project1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        Model1 db = new Model1();
        public ActionResult Index()
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var Userdata = db.Users.Where(c => c.id.Equals(idu)).Take(1).Single();
                return View(Userdata);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult EditProfile()
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var Userdata = db.Users.Where(c => c.id.Equals(idu)).Take(1).Single();
                return View(Userdata);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public ActionResult EditProfile(User u, string datetimepicker)
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var Userdata = db.Users.Where(c => c.id.Equals(idu)).Take(1).Single();
                Userdata.birthday = datetimepicker;
                Userdata.Fname = u.Fname;
                Userdata.lname = u.lname;
                Userdata.bio = u.bio;
                Userdata.BirthPlace = u.BirthPlace;
                Userdata.bodytype = u.bodytype;
                Userdata.city = u.city;
                Userdata.country = u.country;
                Userdata.Diet = u.Diet;
                Userdata.Email = u.Email;
                Userdata.gender = u.gender;
                Userdata.height = u.height;
                Userdata.marriagestatus = u.marriagestatus;
                Userdata.mobile = u.mobile;
                Userdata.occupation = u.occupation;
                Userdata.orientation = u.orientation;
                Userdata.religen = u.religen;
                Userdata.Smokes = u.Smokes;
                Userdata.state = u.state;
                db.Entry(Userdata).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return View(Userdata);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult ChangePassword()
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var Userdata = db.Users.Where(c => c.id.Equals(idu)).Take(1).Single();
                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult ChangePassword(string CurrentPassword, string newpassword)
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                CurrentPassword = Crypto.SHA256(CurrentPassword);
                var Userdata = db.Users.Where(c => c.id.Equals(idu) && c.password.Equals(CurrentPassword)).Take(1).Single();
                newpassword = Crypto.SHA256(newpassword);
                Userdata.password = newpassword;
                db.Entry(Userdata).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }
        public ActionResult Hobbies()
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var userHobies = db.Hobies.Where(c => c.id_user.Equals(idu)).SingleOrDefault();
                return View(userHobies);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult Hobbies(Hoby h)
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var Userhobbies = db.Hobies.Where(c => c.id_user.Equals(idu));
                if (Userhobbies.Count() > 0)
                {
                    var updateHoby = Userhobbies.Take(1).Single();
                    updateHoby.Hobbies = h.Hobbies;
                    updateHoby.favorite_writers = h.favorite_writers;
                    updateHoby.favorite_tvshow = h.favorite_tvshow;
                    updateHoby.favorite_music = h.favorite_music;
                    updateHoby.favorite_movie = h.favorite_movie;
                    updateHoby.favorite_book = h.favorite_book;
                    db.Entry(updateHoby).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    h.id_user = idu;
                    db.Hobies.Add(h);
                }
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }
        public ActionResult EducationAndEmployement()
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var UserData = (from emp in db.Employees
                                where emp.id_user.Equals(idu)                               
                                from edu in db.Educations
                                where edu.id_user.Equals(idu)
                                select new EducationAndEmployementViewModel {
                                    Education_title=edu.Education_title,
                                    Education_place=edu.Education_place,
                                    Edu_Describtion=edu.Describtion,
                                    Employee_Title=emp.Employee_Title,
                                    Employee_place=emp.Employee_place,
                                    Emp_Describtion=emp.Describtion
                               }).SingleOrDefault();
              
                return View(UserData);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult Education(Education Edu)
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var useredu = db.Educations.Where(c => c.id_user.Equals(idu)).SingleOrDefault();
                if (useredu == null)
                {
                    Edu.id_user = idu;
                    db.Educations.Add(Edu);
                }
                else
                {
                    useredu.Education_title = Edu.Education_title;
                    useredu.Education_place = Edu.Education_place;
                    useredu.Describtion = Edu.Describtion;
                    db.Entry(useredu).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult Employee(Employee emp)
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var useremp = db.Employees.Where(c => c.id_user.Equals(idu)).SingleOrDefault();
                if (useremp == null)
                {
                    emp.id_user = idu;
                    db.Employees.Add(emp);
                }
                else
                {
                    useremp.Employee_Title = emp.Employee_Title;
                    useremp.Employee_place = emp.Employee_place;
                    useremp.Describtion = emp.Describtion;
                    db.Entry(useremp).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }
        public ActionResult Notifications()
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var usernotification = db.Notifications.Where(c => c.Id_user.Equals(idu)).OrderByDescending(c=>c.id);
                return View(usernotification);
            }
            catch (Exception)
            {
                
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult FriendsRequests()
        {
            try
            {
                H_project1.Models.Repository.Rep_friends friends = new H_project1.Models.Repository.Rep_friends();
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var requestList = friends.GetFriendRequestforCOntroller(idu);
                return View(requestList);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult AcceptFriend(int id )
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var ReqFriend = db.friends.Where(c => c.idUserRequested.Equals(idu) && c.idUserSendRequest.Equals(id)).SingleOrDefault();
                ReqFriend.accepted = true;
                db.Entry(ReqFriend).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges(); 
                return Json(true, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }
        [HttpPost]
        public JsonResult IgnorFriend(int id)
        {
            try
            {
                int idu = Convert.ToInt32(Request.Cookies["idlogin"].Value);
                var ReqFriend = db.friends.Where(c => c.idUserRequested.Equals(idu) && c.idUserSendRequest.Equals(id)).SingleOrDefault();
                ReqFriend.Ignored = true;
                db.Entry(ReqFriend).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

    }
}