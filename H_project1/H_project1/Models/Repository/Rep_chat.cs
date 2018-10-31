using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H_project1.Models.AccessData;
using H_project1.Models.Utilitis;
using H_project1.Models.ViewModel;
namespace H_project1.Models.Repository
{
    public class Rep_chat
    {
        Model1 db = new Model1();
        public List<UserMessageViewModel> GetListOfmessage(int id)
        {
            try
            {
                var ListOfUserMessage = (from m in db.messages
                                        join u in db.Users on m.IdUserResiver equals u.id
                                        where u.id.Equals(id) && m.seen.Equals(false)
                                        orderby m.id descending
                                        select new UserMessageViewModel { U = u, M = m }).ToList();
 
                return ListOfUserMessage;

            }
            catch (Exception ex)
            {
                var a = ex;
                return null;
            }
        }
    }
}