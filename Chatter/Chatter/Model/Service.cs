using Chatter.Model.BLL;
using Chatter.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        #region User crud
        public IEnumerable<User> GetUsers()
        {

            // se till att det är sorterat efter UserId
            return UserDAL.GetUsers().OrderBy(o => o.UserId);
        }

        public User GetUserById(int userId) 
        {
            return UserDAL.GetUserById(userId);
        }

        public void DeleteUser(int userId)
        {
            UserDAL.DeleteUser(userId);
        }

        public void InsertUser(User user)
        {
            ICollection<ValidationResult> validationResults;
            if (!user.Validate(out validationResults))
            {
                throw new AggregateException("Objektet klarade inte valideringen.",
                    validationResults.Select(vr => new ValidationException(vr.ErrorMessage)).ToList().AsReadOnly());
            }

            UserDAL.InsertUser(user);
        }
        #endregion

        #region UserInfo Crud
        public IEnumerable<UserInfo> GetUserInfo()
        {
            // se till att det som returneras är sorterat efter UserId
            // så det matchar med GetUsers() när de skrivs ut i ListViews
            return UserInfoDAL.GetUserInfo().OrderBy(o => o.UserId);
        }

        public UserInfo GetUserInfoByUserId(int userId)
        {
            return UserInfoDAL.GetUserInfoByUserId(userId);
        }

        public UserInfo GetUserInfoById(int userInfoId)
        {
            return UserInfoDAL.GetUserInfoById(userInfoId);
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            ICollection<ValidationResult> validationResults;
            if (!userInfo.Validate(out validationResults))
            {
                throw new AggregateException("Objektet klarade inte valideringen.",
                    validationResults.Select(vr => new ValidationException(vr.ErrorMessage)).ToList().AsReadOnly());
            }

            UserInfoDAL.UpdateUserInfo(userInfo);
        }

        public void InsertUserInfo(UserInfo userInfo)
        {
            ICollection<ValidationResult> validationResults;
            if (!userInfo.Validate(out validationResults))
            {
                throw new AggregateException("Objektet klarade inte valideringen.",
                    validationResults.Select(vr => new ValidationException(vr.ErrorMessage)).ToList().AsReadOnly());
            }
            UserInfoDAL.InsertUserInfo(userInfo);
        }
        #endregion

        #region BlogPost Crud
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return BlogPostDAL.GetBlogPosts();
        }

        public BlogPost GetBlogPostById(int blogPostId)
        {
            return BlogPostDAL.GetBlogPostById(blogPostId);
        }


        public void InsertBlogPost(BlogPost blogPost)
        {
            ICollection<ValidationResult> validationResults;
            if (!blogPost.Validate(out validationResults))
            {
                throw new AggregateException("Objektet klarade inte valideringen.",
                    validationResults.Select(vr => new ValidationException(vr.ErrorMessage)).ToList().AsReadOnly());
            }

            BlogPostDAL.InsertBlogPost(blogPost);
        }

        public void DeleteBlogPost(int blogPostId)
        {
            BlogPostDAL.DeleteBlogPost(blogPostId);
        }

        public void UpdateBlogPost(BlogPost blogPost)
        {
            ICollection<ValidationResult> validationResults;
            if (!blogPost.Validate(out validationResults))
            {
                throw new AggregateException("Objektet klarade inte valideringen.",
                    validationResults.Select(vr => new ValidationException(vr.ErrorMessage)).ToList().AsReadOnly());
            }

            BlogPostDAL.UpdateBlogPost(blogPost);
        }
        #endregion

    }
}