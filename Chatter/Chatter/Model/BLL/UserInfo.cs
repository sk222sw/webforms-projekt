using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatter.Model.BLL
{
    public class UserInfo : BusinessObjectClass
    {
        public int UserInfoId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage="Fyll i ett namn")]
        [StringLength(40, ErrorMessage="Namnet får inte vara länge än 40 tecken.")]
        public string Name { get; set; }
        [Required(ErrorMessage="Fyll i en e-post.")]
        [EmailAddress(ErrorMessage = "E-posten har fel format.")]
        [StringLength(50, ErrorMessage="E-posten får inte vara längre än 50 tecken.")]
        public string Email { get; set; }

    }
}