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
        private UserInfoDAL _userInfoDAL;

        private UserDAL UserDAL
        {
            get { return _userDAL ?? (_userDAL = new UserDAL()); }
        }
        private UserInfoDAL UserInfoDAL
        {
            get { return _userInfoDAL ?? (_userInfoDAL = new UserInfoDAL()); }
        }

        public IEnumerable<User> GetUsers()
        {
            return UserDAL.GetUsers();
        }

        public IEnumerable<UserInfo> GetUserInfo()
        {
            return UserInfoDAL.GetUserInfo();
        }

    }
}