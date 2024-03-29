﻿using Chatter.Model.BLL;
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
                try
                {

                    var blogPosts = new List<BlogPost>(100);

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetBlogPosts", conn);
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
                                UserId = reader.GetInt32(UserIdIndex),
                                Title = reader.GetString(TitleIndex),
                                Message = reader.GetString(MessageIndex),
                                Date = reader.GetDateTime(DateIndex)
                            });
                        }

                        blogPosts.TrimExcess();
                        return blogPosts;

                    }
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när posterna skulle hämtas.");
                }


            }
        }

        public BlogPost GetBlogPostById(int blogPostId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspGetBlogPostById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BlogPostId", SqlDbType.Int, 4).Value = blogPostId;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int blogPostIdIndex = reader.GetOrdinal("BlogPostId");
                            int userIdIndex = reader.GetOrdinal("UserId");
                            int titleIndex = reader.GetOrdinal("Title");
                            int messageIndex = reader.GetOrdinal("Message");

                            return new BlogPost
                            {
                                BlogPostId = reader.GetInt32(blogPostIdIndex),
                                UserId = reader.GetInt32(userIdIndex),
                                Title = reader.GetString(titleIndex),
                                Message = reader.GetString(messageIndex)
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när posten skulle hämtas.");
                }
            }
        }

        public void InsertBlogPost(BlogPost blogPost)
        {
            using(var conn = CreateConnection())
	        {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertBlogPost", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = blogPost.UserId;
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 50).Value = blogPost.Title;
                    cmd.Parameters.Add("@Message", SqlDbType.VarChar, 200).Value = blogPost.Message;
                    cmd.Parameters.Add("@BlogPostId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när posterna skulle hämtas.");
                }
	        }
        }

        public void DeleteBlogPost(int blogPostId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.uspDeleteBlogPost", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BlogPostId", SqlDbType.Int, 4).Value = blogPostId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när posterna skulle hämtas.");
                }
            }
        }

        public void UpdateBlogPost(BlogPost blogPost)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateBlogPost", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BlogPostId", SqlDbType.Int, 4).Value = blogPost.BlogPostId;
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 50).Value = blogPost.Title;
                    cmd.Parameters.Add("@Message", SqlDbType.VarChar, 200).Value = blogPost.Message;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när posterna skulle hämtas.");
                }
            }
        }
    }
}