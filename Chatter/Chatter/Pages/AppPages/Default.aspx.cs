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
    public partial class Default : System.Web.UI.Page
    {

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<User> UserListView_GetData()
        {
            return Service.GetUsers();
        }

        public IEnumerable<UserInfo> UserInfoListView_GetData()
        {
            return Service.GetUserInfo();
        }

    }
}