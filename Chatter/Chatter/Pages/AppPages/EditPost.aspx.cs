using Chatter.Model;
using Chatter.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chatter.Pages.AppPages
{
    public partial class EditPost : System.Web.UI.Page
    {
        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void BlogPostFormView_UpdateItem(int blogPostId)
        {
            var blogPost = Service.GetBlogPostById(blogPostId);

            if (TryUpdateModel(blogPost))
            {
                Service.UpdateBlogPost(blogPost);
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public BlogPost EditBlogPostFormView_GetItem([RouteData] int id)
        {
            return Service.GetBlogPostById(id);
        }
    }
}