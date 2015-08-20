using Chatter.Model;
using Chatter.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chatter.Pages.AppPages
{
    public partial class Posts : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<BlogPost> BlogPostListView_GetData()
        {
            return Service.GetBlogPosts();
        }

        public User GetUser(int userId) 
        {
            return Service.GetUserById(userId);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void BlogPostListView_DeleteMethod(int blogPostId)
        {
            Service.DeleteBlogPost(blogPostId);
        }


    }
}