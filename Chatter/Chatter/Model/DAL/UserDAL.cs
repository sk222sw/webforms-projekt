using Chatter.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Chatter.Model.DAL
{
    public class UserDAL : DALBase
    {
        //hämta alla användare och 
        //returnera en referens till listobjektet users
        public IEnumerable<User> GetUsers()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var users = new List<User>(100);

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        //hämta kolumn-index för tabellen
                        var userIdIndex = reader.GetOrdinal("UserId");
                        var userName = reader.GetOrdinal("UserName");

                        //hämta data och lägg till i listan users
                        //så länge reader.Read() hittar poster
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserId = reader.GetInt32(userIdIndex),
                                UserName = reader.GetString(userName)
                            });
                        }

                        //ta bort överflödiga poster från listan
                        //innan den returneras
                        users.TrimExcess();
                        return users;
                    }
                }
                catch
                {

                    throw new ApplicationException("Ett fel inträffade när användarna skulle hämtas.");
                }

            }
        }

        public User GetUserById(int userId)
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var cmd = new SqlCommand("appSchema.uspGetUserById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@userId", SqlDbType.Int, 4).Value = userId;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userIdIndex = reader.GetOrdinal("UserId");
                            int userNameIndex = reader.GetOrdinal("UserName");

                            return new User
                            {
                                UserId = reader.GetInt32(userIdIndex),
                                UserName = reader.GetString(userNameIndex)
                            };
                        }
                        return null;
                    }
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när användaren skulle hämtas.");
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var cmd = new SqlCommand("appSchema.uspDeleteUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@userId", SqlDbType.Int, 4).Value = userId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch 
                {
                    throw new ApplicationException("Ett fel inträffade när användaren skulle tas bort.");
                }
            }
        }

        public void InsertUser(User user)
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 40).Value = user.UserName;
                    cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();


                    cmd.ExecuteNonQuery();
                    //user.UserId = (int)(cmd.Parameters["@UserId"].Value);
                }
                catch 
                {
                    throw new ApplicationException("Ett fel inträffade när användaren skulle skapas.");
                }
            }
        }

    }
}