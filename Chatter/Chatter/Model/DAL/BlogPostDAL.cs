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

        public void InsertBlogPost(BlogPost blogPost)
        {
            using(var conn = CreateConnection())
	        {
                SqlCommand cmd = new SqlCommand("dbo.uspInsertBlogPost", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = blogPost.UserId;
                cmd.Parameters.Add("@Title", SqlDbType.VarChar, 50).Value = blogPost.Title;
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 200).Value = blogPost.Message;
                cmd.Parameters.Add("@BlogPostId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                conn.Open();

                cmd.ExecuteNonQuery();
	        }
        }

    }
}