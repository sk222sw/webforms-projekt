﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Chatter
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoute(RouteTable.Routes);
            var jQuery = new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-2.1.4.min.js",
                DebugPath = "~/Scripts/jquery-2.1.4.js",
                CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jqiery-2.1.4.min.js",
                CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jqiery-2.1.4.js"
            };
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}