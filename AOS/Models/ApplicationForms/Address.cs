using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AOS.Models.ApplicationForms
{
    public class PhysicalAddress
    {
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        [Required]
        [StringLength(30, ErrorMessage = "The Country should be at least 4 letters long ", MinimumLength = 4)]
        public Countries Country { set; get; }

        [DataType(DataType.Text)]
        [Display(Name = "Region")]
        [StringLength(30, ErrorMessage = "The Region should be at least 2 letters long ", MinimumLength = 2)]
        public string Region { set; get; }

        [DataType(DataType.Text)]
        [Display(Name = "City")]
        [Required]
        [StringLength(30, ErrorMessage = "The City should be at least 2 letters long ", MinimumLength = 2)]
        public string City { set; get; }

        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        [Required]
        [StringLength(30, ErrorMessage = "The Address should be at least 2 letters long ", MinimumLength = 2)]
        public string Address { set; get; }

        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal Code")]
        [Required]
        [StringLength(30, ErrorMessage = "The code should be at least 2 letters long ", MinimumLength = 2)]
        public string Postal { set; get; }

        [Display(Name = ("Telephone"))]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [StringLength(15, ErrorMessage = "The phone should be at least 5 letters long ", MinimumLength = 5)]
        public string Phone { set; get; }
        [Display(Name = ("Fax"))]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [StringLength(30, ErrorMessage = "The phone should be at least 5 letters long ", MinimumLength = 5)]
        public string Fax { set; get; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = ("Email Address"))]
        [Required]
        public string Email { set; get; }
    }
}