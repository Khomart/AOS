using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AOS.Models.UserEntities
{
    public class  Person
    {
        [Key]
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
    }
}