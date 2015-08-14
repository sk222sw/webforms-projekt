using Chatter.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Chatter.Model.DAL
{
    public class BlogPostDAL : DALBase
    {
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            using (var conn = CreateConnection())
            {

                var blogPosts = new List<BlogPost>(100);

                SqlCommand cmd = new SqlCommand("dbo.uspGetBlogPosts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    //hämta kolumn-index för tabellen'
                    var blogPostIdIndex = reader.GetOrdinal("BlogPostId");
                    var UserIdIndex = reader.GetOrdinal("UserId");
                    var TitleIndex = reader.GetOrdinal("Title");
                    var MessageIndex = reader.GetOrdinal("Message");
                    var DateIndex = reader.GetOrdinal("Date");

                    while (reader.Read())
                    {
                        blogPosts.Add(new BlogPost
                        {
                            BlogPostId = reader.GetInt32(blogPostIdIndex),
                            UserId =  reader.GetInt32(UserIdIndex),
                            Title = reader.GetString(TitleIndex),
                            Message = reader.GetString(MessageIndex),
                            Date = reader.GetDateTime(DateIndex)
                        });
                    }

                    blogPosts.TrimExcess();
                    return blogPosts;

                }


            }
        }
    }
}