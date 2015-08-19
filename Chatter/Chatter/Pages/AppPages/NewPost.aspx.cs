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
    public partial class NewPost : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<User> GetUsers()
        {
            return Service.GetUsers();
        }

        public void BlogPostFormView_InsertItem(BlogPost blogPost)
        {
            blogPost.UserId = Convert.ToInt32(Request.Form["selectList"]);
            Service.InsertBlogPost(blogPost);
        }
    }
}