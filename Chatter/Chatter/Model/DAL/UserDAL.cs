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
                var users = new List<User>(100);

                SqlCommand cmd = new SqlCommand("dbo.uspGetUser", conn);
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
        }
    }
}