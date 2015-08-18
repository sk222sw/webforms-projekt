﻿using Chatter.Model;
using Chatter.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chatter.Pages.AppPages
{
    public partial class NewUser : System.Web.UI.Page
    {

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void NewUserFormView_InsertItem(User user)
        {
            Service.InsertUser(user);

            Response.RedirectToRoute("NewUserInfo", new { id = user.UserId });
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}