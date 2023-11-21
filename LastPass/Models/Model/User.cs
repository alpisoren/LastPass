using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using LastPass.Models.Model.BaseEntity;
namespace LastPass.Models.Model
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Required, StringLength(50, ErrorMessage = "50 Karakter olmalıdır")]
        public string Password { get; set; }

        [Required, StringLength(50, ErrorMessage = "50 Karakter olmalıdır")]
        public string UserName { get; set; }

        public string Email { get; set; }

    }
}