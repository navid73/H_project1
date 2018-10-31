using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H_project1.Models.AccessData;
using System.Text.RegularExpressions;

namespace H_project1.Models.Utilitis
{
    public class VerifyEmail
    {
        Model1 db = new Model1();
        public int VEmail(string email)
        {
            var q = (db.Users.Where(c => c.Email.Equals(email))).ToList();
            string regexPattern = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$";

            bool validemail = new Regex(regexPattern, RegexOptions.IgnoreCase).IsMatch(email);
            if (validemail && q.Count()==0)
            {
                return 0;
            }
            else if(validemail && q.Count()!=0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}