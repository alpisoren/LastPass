using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LastPass.Models.Model
{
    [Table("PasswordRecord")]
    public class PasswordRecord : BaseEntity
    {
        public string  Info { get; set; }

        [Required, StringLength(50, ErrorMessage = "50 Karakter olmalıdır")]
        public string URL { get; set; }

        [Required, StringLength(50, ErrorMessage = "50 Karakter olmalıdır")]
        public string UserName { get; set; }

        [Required, StringLength(50, ErrorMessage = "50 Karakter olmalıdır")]
        public string Password { get; set; }

        public PasswordCategory PasswordCategory { get; set; }
    }
}