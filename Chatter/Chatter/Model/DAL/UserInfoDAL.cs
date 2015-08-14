using Chatter.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Chatter.Model.DAL
{
    public class UserInfoDAL : DALBase
    {
        //Hämtar all användarinfo och returnerar
        //en referens till ett listobjekt med användarinfoobjektsreferenser
        public IEnumerable<UserInfo> GetUserInfo()
        {
            using (var conn = CreateConnection())
            {
                var userInfos = new List<UserInfo>(100);

                SqlCommand cmd = new SqlCommand("dbo.uspGetUserInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    //hämta kolumnindex
                    var userInfoIdIndex = reader.GetOrdinal("UserInfoId");
                    var userIdIndex = reader.GetOrdinal("UserId");
                    var NameIndex = reader.GetOrdinal("Name");
                    var EmailIndex = reader.GetOrdinal("Email");

                    //fyll listan med objektreferenser
                    while (reader.Read())
                    {
                        userInfos.Add(new UserInfo
                        {
                            UserInfoId = reader.GetInt32(userInfoIdIndex),
                            UserId = reader.GetInt32(userIdIndex),
                            Name = reader.GetString(NameIndex),
                            Email = reader.GetString(EmailIndex)
                        });
                    }

                    //ta bort överflödiga poster i listan
                    // och returnera den
                    userInfos.TrimExcess();
                    return userInfos;
                }
            }
        }
    }
}