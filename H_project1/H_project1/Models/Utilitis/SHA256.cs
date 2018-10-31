using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace H_project1.Models.Utilitis
{
    public class SHA256
    {
        public string DataSHA256(string data)
        {
            data = Crypto.SHA256(data);
            return data;
        }



    }
}