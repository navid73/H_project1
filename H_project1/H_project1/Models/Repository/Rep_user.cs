using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H_project1.Models.AccessData;
using H_project1.Models.Utilitis;

namespace H_project1.Models.Repository
{
    public class Rep_user
    {
        Model1 db = new Model1();
        SHA256 Crypt = new SHA256();
        public bool AddUser(User U)
        {
            try
            {
                var Date = DateTime.Now.ToString();
                U.SignUpDate = Date;
                db.Users.Add(U);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        public User GetUserData(int id)
        {
            try
            {
                var userData = db.Users.Where(c => c.id.Equals(id)).Take(1).Single();
                return userData;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
      


    }
}