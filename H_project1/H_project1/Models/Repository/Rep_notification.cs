using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H_project1.Models.AccessData;
using H_project1.Models.Utilitis;
using H_project1.Models.ViewModel;

namespace H_project1.Models.Repository
{
    public class Rep_notification
    {
        Model1 db = new Model1();
        public List<Notification> GetlistOfNotification(int id)
        {
            try
            {
                var listOfUserNotification = db.Notifications.Where(c => c.Id_user.Equals(id) && c.seen.Equals(false)).ToList();
              
                return listOfUserNotification;
            }
            catch (Exception)
            {
                
                return null;
            }
        }
       
    }
}