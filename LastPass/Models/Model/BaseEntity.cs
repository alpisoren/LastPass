using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LastPass.Models.Model
{
    public partial class BaseEntity
    {
        [Key]
        public int Id { get; set; }



    }
}