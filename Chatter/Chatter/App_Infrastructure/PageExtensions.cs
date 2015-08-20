using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Chatter.App_Infrastructure
{
    public static class PageExtensions
    {

        //hämta temporärt sparade meddelanden
        public static object GetTempData(this Page page, string key)
        {
            var value = page.Session[key];
            page.Session.Remove(key);
            return value;
        }

        //sätt meddelanden till sessions
        public static void SetTempData(this Page page, string key, object value)
        {
            page.Session[key] = value;
        }


    }
}