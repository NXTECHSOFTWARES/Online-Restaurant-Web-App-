using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class Tbl_Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage ="Please provide your First Name")]
        [StringLength(50)]
        public string CustomerFirstName { get; set; }

        [DisplayName("Surname")]
        [Required(ErrorMessage = "Please provide your Last Name")]
        [StringLength(50)]
        public string CustomerLastName { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Please provide your gender")]
        [StringLength(50)]
        public string CustomerGender { get; set; }

        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage = "Please provide your Date Of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime CustomerDateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Surburb is required")]
        [StringLength(40)]
        public string Surburb { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }

        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "Please provide your Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string CustomerMobileNumber { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Please provide your Email Address")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmailAddress { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Please create a password")]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }

        //[DisplayName("Confirm Password")]
        //[Required(ErrorMessage = "Please fill in the Password for confirmation")]
        //[DataType(DataType.Password)]
        //[Compare("CustomerPassword")]
        //public string ConfirmPassword { get; set; }
    }
}