using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Chatter
{
    public class RouteConfig
    {
        public static void RegisterRoute(RouteCollection routes)
        {
            routes.MapPageRoute("Default", "", "~/Pages/AppPages/Posts.aspx");
            routes.MapPageRoute("Posts", "meddelanden", "~/Pages/AppPages/Posts.aspx");
            routes.MapPageRoute("NewPost", "meddelande/nytt", "~/Pages/AppPages/NewPost.aspx");
            routes.MapPageRoute("UserList", "users", "~/Pages/AppPages/UserList.aspx");
        }
    }
}