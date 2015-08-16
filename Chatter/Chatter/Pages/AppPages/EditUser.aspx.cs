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
    public partial class EditUser : System.Web.UI.Page
    {

        private Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Chatter.Model.BLL.User EditUserFormView_GetItem([RouteData] int id)
        {
            return Service.GetUserById(id);
        }

        public UserInfo GetUserInfoByUserId(int userId)
        {
            return Service.GetUserInfoByUserId(userId);
        }

    }
}