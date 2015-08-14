using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatter.Model.BLL
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}