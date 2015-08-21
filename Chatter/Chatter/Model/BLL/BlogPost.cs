using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatter.Model.BLL
{
    public class BlogPost : BusinessObjectClass
    {
        public int BlogPostId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Skriv in en titel.")]
        [StringLength(50, ErrorMessage="Max 50 tecken i titeln.")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Skriv in ett meddelande.")]
        [StringLength(200, ErrorMessage="Max 200 tecken i meddelandet.")]
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}