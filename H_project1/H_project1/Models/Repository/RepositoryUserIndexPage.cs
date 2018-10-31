using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H_project1.Models.AccessData;
using H_project1.Models.Utilitis;
using H_project1.Models.ViewModel;

namespace H_project1.Models.Repository
{
    public class RepositoryUserIndexPage
    {
        Model1 db = new Model1();
        public List<FriendsNewPostViewModel> FriendNewPosts(int id)
        {
            var getUserFriendsId = db.friends.Where(c => c.idUserSendRequest.Equals(id) && c.accepted.Equals(true) || c.idUserRequested.Equals(id) && c.accepted.Equals(true)).Select(c => new FriendId { Fid = c.idUserRequested, UFid = c.idUserSendRequest });

            var friendpost = (from p in db.UsersPosts
                              join fid in getUserFriendsId on p.id_User equals fid.Fid
                              orderby p.id descending
                              select new FriendsNewPostViewModel { p = p }).ToList();
            return friendpost;



        }
        public List<UsersPost> posts(int id)
        {
            var userpost = db.UsersPosts.Where(c => c.id_User==id).OrderByDescending(c => c.id).ToList();
            return userpost;
        }
        public List<PostCommentUserviewClass> PostComment(List<int> id)
        {

            //var userpost = db.UsersPosts.Where(c => c.id_User.Equals(id)).Select(c => c.id).ToList();
            var postcoment = (from pc in db.Post_Comment
                              join u in db.Users on pc.UserId equals u.id
                              where id.Contains(pc.PostId)
                              select new PostCommentUserviewClass { pc = pc, U = u }).ToList();
            return postcoment;
        }


    }

}