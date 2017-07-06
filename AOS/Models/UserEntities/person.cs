using AOS.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AOS.Models.UserEntities
{
    public class  Person
    {
        [Key]
        public int ID { set; get; }
        [ForeignKey("User")]
        [Required]
        public int UserID { set; get; }
        public virtual ApplicationUser User { set; get; }
    }
}