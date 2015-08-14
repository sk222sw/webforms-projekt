using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatter.Model.BLL
{
    public class UserInfo
    {
        public int UserInfoId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}