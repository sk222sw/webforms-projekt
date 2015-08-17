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
            //                  routename           /urlnamn                    path    
            routes.MapPageRoute("Default",          "",                         "~/Pages/AppPages/Posts.aspx");
            routes.MapPageRoute("Posts",            "meddelanden",              "~/Pages/AppPages/Posts.aspx");
            routes.MapPageRoute("NewPost",          "meddelande/nytt",          "~/Pages/AppPages/NewPost.aspx");
            routes.MapPageRoute("UserList",         "användare",                "~/Pages/AppPages/UserList.aspx");
            routes.MapPageRoute("UserDetails",      "användare/{id}",           "~/Pages/AppPages/UserList.aspx");
            routes.MapPageRoute("EditUser",         "användare/{id}/redigera",  "~/Pages/AppPages/EditUser.aspx");
            routes.MapPageRoute("NewUser",          "ny",                       "~/Pages/AppPages/NewUser.aspx");
        }
    }
}