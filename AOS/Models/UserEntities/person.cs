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
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string SecondName { set; get; }
        [ForeignKey("UserLink")]
        [Required]
        public int UserLinkId { set; get; }
        public virtual ApplicationUser UserLink { set; get; }
    }
}