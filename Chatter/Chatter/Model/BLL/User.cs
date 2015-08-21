using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatter.Model.BLL
{
    public class User : BusinessObjectClass
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "ERRORPLATS:KLASS Ange användarnamn")]
        [StringLength(20, ErrorMessage = "ERRORPLATS:KLASS Max 20 tecken")]
        public string UserName { get; set; }
    }
}