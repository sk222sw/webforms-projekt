using Chatter.Model.BLL;
using Chatter.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatter.Model
{
    public class Service
    {
        private UserDAL _userDAL;

        private UserDAL UserDAL
        {
            get { return _userDAL ?? (_userDAL = new UserDAL()); }
        }

        public IEnumerable<User> GetUsers()
        {
            return UserDAL.GetUsers();
        }

        public IEnumerable<UserInfo> GetUserInfo()
        {
            return null;
        }

    }
}