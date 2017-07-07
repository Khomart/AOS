using AOS.Models.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AOS.Models.ApplicationForms
{
    public class FOAFSample
    {

        [ForeignKey("State")]
        public int ID { set; get; }
        public virtual State State { set; get; }

        [DataType(DataType.Text)]
        [Display(Name = ("Name"))]
        public string Name { set; get; }
        [DataType(DataType.Text)]
        [Display(Name = ("Trading Name"))]
        public string TradingName { set; get; }

        //Company address
        [Display(Name = ("Company Address"))]
        public PhysicalAddress CompanyAddress { set; get; }

        //Place Of Business Address
        [Display(Name = ("Business Address"))]
        public PhysicalAddress BusinessAddress { set; get; }


        //Principal Place Of Business
        //[DataType(DataType.Text)]
        //[Display(Name = ("Business Address"))]
        //public string BusinessAdress { set; get; }
        //[DataType(DataType.Text)]
        //[Display(Name = ("Business Telephone"))]
        //public string BusinessPhone { set; get; }
        //[DataType(DataType.Text)]
        //[Display(Name = ("Business Fax"))]
        //public string BusinessFax { set; get; }
        //[DataType(DataType.EmailAddress)]
        //[Display(Name = ("Business Email"))]
        //public string BusinessEmail { set; get; }

        //Start-up date propose:
        [DataType(DataType.DateTime)]
        [Display(Name = "Start-up Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime StartupDate { set; get; }

        //ICAO designator 
        [DataType(DataType.Text)]
        [Display(Name = "ICAO Designator")]
        [StringLength(3, ErrorMessage = "The Designator shoul be 3-letter long ",MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Designator { set; get; }

        //Operational Management Personnel
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "The name should be at least 2 letters long ", MinimumLength = 2)]
        public string FirstName { set; get; }
        [DataType(DataType.Text)]
        [Display(Name = "Second Name")]
        [StringLength(20, ErrorMessage = "The name should be at least 2 letters long ", MinimumLength = 2)]
        public string SecondName { set; get; }
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        [StringLength(30, ErrorMessage = "The title should be at least 2 letters long ", MinimumLength = 2)]
        public string Title { set; get; }
        [Display(Name = ("Personnel Telephone"))]
        public string PersonnelPhone { set; get; }
        [Display(Name = ("Personnel Fax"))]
        public string PersonnelFax { set; get; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = ("Personnel Email Address"))]
        public string PersonnelEmail { set; get; }



        //entitySpecific
        [DataType(DataType.DateTime)]
        [Display(Name = "Created On")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime CreatedOn { set; get; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Edited")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime Edited { set; get; }

        [Display(Name = "Archived")]
        public bool Archived  { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }



        public FOAFSample()
        {
            CompanyAddress = new PhysicalAddress();
            BusinessAddress = new PhysicalAddress();
            Archived = false;
            //StartupDate = DateTime.Today;
        }




    }
}