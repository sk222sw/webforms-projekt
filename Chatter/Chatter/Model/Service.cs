using Chatter.Model.BLL;
using Chatter.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Chatter.Model
{
    public class Service
    {
        #region fält
        private UserDAL _userDAL;
        private UserInfoDAL _userInfoDAL;
        private BlogPostDAL _blogPostDAL;
        #endregion

        #region egenskaper
        private UserDAL UserDAL
        {
            get { return _userDAL ?? (_userDAL = new UserDAL()); }
        }
        private UserInfoDAL UserInfoDAL
        {
            get { return _userInfoDAL ?? (_userInfoDAL = new UserInfoDAL()); }
        }
        private BlogPostDAL BlogPostDAL
        {
            get { return _blogPostDAL ?? (_blogPostDAL = new BlogPostDAL()); }
        }
        #endregion

        public IEnumerable<User> GetUsers()
        {
            // se till att det är sorterat efter UserId
            return UserDAL.GetUsers().OrderBy(o => o.UserId);
        }

        public User GetUserById(int userId) 
        {
            return UserDAL.GetUserById(userId);
        }

        public IEnumerable<UserInfo> GetUserInfo()
        {
            // se till att det som returneras är sorterat efter UserId
            // så det matchar med GetUsers() när de skrivs ut i ListViews
            return UserInfoDAL.GetUserInfo().OrderBy(o => o.UserId);
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return BlogPostDAL.GetBlogPosts();
        }

    }
}