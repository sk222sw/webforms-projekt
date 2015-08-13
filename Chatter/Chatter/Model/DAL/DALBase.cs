using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Chatter.Model.DAL
{
    public abstract class DALBase
    {
        private static string _connectionString;

        static DALBase ()
	    {
            _connectionString = WebConfigurationManager.ConnectionStrings["ChatterConnectionString"].ConnectionString;
    	}

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}