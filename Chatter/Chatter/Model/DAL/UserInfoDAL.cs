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

        public UserInfo GetUserInfoByUserId(int userId)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.uspGetUserInfoByUserId", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = userId;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userInfoIdIndex = reader.GetOrdinal("UserInfoId");
                        int userIdIndex = reader.GetOrdinal("UserId");
                        int nameIndex = reader.GetOrdinal("Name");
                        int emailIndex = reader.GetOrdinal("Email");

                        return new UserInfo
                        {
                            UserInfoId = reader.GetInt32(userInfoIdIndex),
                            UserId = reader.GetInt32(userIdIndex),
                            Name = reader.GetString(nameIndex),
                            Email = reader.GetString(emailIndex)
                        };
                    }
                }
                return null;

            }
        }

        public UserInfo GetUserInfoById(int userInfoId)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.uspGetUserInfoById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserInfoId", SqlDbType.Int, 4).Value = userInfoId;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userInfoIdIndex = reader.GetOrdinal("UserInfoId");
                        int userIdIndex = reader.GetOrdinal("UserId");
                        int nameIndex = reader.GetOrdinal("Name");
                        int emailIndex = reader.GetOrdinal("Email");

                        return new UserInfo
                        {
                            UserInfoId = reader.GetInt32(userInfoIdIndex),
                            UserId = reader.GetInt32(userIdIndex),
                            Name = reader.GetString(nameIndex),
                            Email = reader.GetString(emailIndex)
                        };
                    }
                }
                return null;

            }
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.uspUpdateUserInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserInfoId", SqlDbType.Int, 4).Value = userInfo.UserInfoId;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = userInfo.Name;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = userInfo.Email;

                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteUserInfo(int userInfoId)
        {
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("dbo.uspDeleteUserInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@userInfoId", SqlDbType.Int, 4).Value = userInfoId;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertUserInfo(UserInfo userInfo)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.uspInsertUserInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = userInfo.UserId;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = userInfo.Name;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = userInfo.Email;
                cmd.Parameters.Add("@UserInfoId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                conn.Open();

                cmd.ExecuteNonQuery();

                //userInfo.UserInfoId = (int)cmd.Parameters["@UserInfoId"].Value;
            }
        }

    }
}