using AOS.Models.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AOS.Models.UserEntities
{
    public class State : Person
    {
        //[Display(Name = "State Name")]
        //public string Name { set; get; }
        //[Display(Name = "Short Name")]
        //public string Short { set; get; }
        [Timestamp]
        public byte[] RowVersion { get; set; }


        //[ForeignKey("User")]
        //public int UserID { set; get; }
        //public ApplicationUser User { set; get; }
    }
}