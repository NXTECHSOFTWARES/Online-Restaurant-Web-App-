using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class Tbl_Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required(ErrorMessage = "Please provide a valid Driver's ID Number")]
        public string DriverIDNumber { get; set; }

        [Required(ErrorMessage = "Please provide Drivers First Name")]
        [StringLength(50)]
        public string DriverFirstName { get; set; }

        [Required(ErrorMessage = "Please provide Drivers Last Name")]
        [StringLength(50)]
        public string DriverLastName { get; set; }

        [Required(ErrorMessage = "Please provide Drivers gender")]
        [StringLength(50)]
        public string DriverGender { get; set; }

        [Required(ErrorMessage = "Please provide Driver's Date Of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime DriverDateOfBirth { get; set; }

        [Required(ErrorMessage = "Please provide Driver's Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string DriverMobileNumber { get; set; }

        [Required(ErrorMessage = "Please provide Driver's Email Address")]
        [DataType(DataType.EmailAddress)]
        public string DriverEmailAddress { get; set; }

        [Required(ErrorMessage = "Please provide Driver's Driver License")]
        public string DriverDriverLicense { get; set; }

        [Required(ErrorMessage = "Please create password for Driver")]
        [DataType(DataType.Password)]
        public string DriverPassword { get; set; }

        //[Required(ErrorMessage = "Please fill in the Password for confirmation")]
        //[DataType(DataType.Password)]
        //[Compare("CustomerPassword")]
        //public string ConfirmPassword { get; set; }

    }
}