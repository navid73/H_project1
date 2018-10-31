using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H_project1.Models.AccessData;
using H_project1.Models.Utilitis;
using H_project1.Models.ViewModel;


namespace H_project1.Models.Repository
{
    public class Rep_friends
    {
        Model1 db = new Model1();
        public IEnumerable<User> GetFriendRequest(int id)
        {
            try
            {
                //var friends = (from f in db.friends
                //               join u in db.Users on f.idUserRequested equals u.id
                //               where f.accepted.Equals(false) && f.Ignored.Equals(false)&& f.idUserRequested.Equals(id)
                //               orderby f.id descending
                //               select new FriendRequestViewModel { U = u, F = f }).Take(4).ToList();
                var friends = db.friends.Where(c => c.idUserRequested.Equals(id) && c.Ignored == false && c.accepted == false).OrderByDescending(c => c.id).Select(c => c.idUserSendRequest).Take(4).ToList();

                var friend2 = from f in db.Users
                              where friends.Contains(f.id)
                              select f;

                return friend2;

            }
            catch (Exception)
            {

                return null;
            }
        }
        public IEnumerable<User> GetFriendRequestforCOntroller(int id)
        {
            try
            {
                //var friends = (from f in db.friends
                //               join u in db.Users on f.idUserRequested equals u.id
                //               where f.accepted.Equals(false) && f.Ignored.Equals(false)&& f.idUserRequested.Equals(id)
                //               orderby f.id descending
                //               select new FriendRequestViewModel { U = u, F = f }).Take(4).ToList();
                var friends = db.friends.Where(c => c.idUserRequested.Equals(id) && c.Ignored == false && c.accepted == false).OrderByDescending(c => c.id).Select(c => c.idUserSendRequest).ToList();

                var friend2 = from f in db.Users
                              where friends.Contains(f.id)
                              select f;

                return friend2;

            }
            catch (Exception)
            {

                return null;
            }
        }


    }
}