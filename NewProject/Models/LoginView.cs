using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace   NewProject.Models
{
    public class LoginView
    {
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }

    public class CustomSerializeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> RoleName { get; set; }

    }

    public class RegistrationView
    {
        [Required(ErrorMessage = "User Name required")]
        [Display(Name ="User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First Name required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Gender")]
        [Required(ErrorMessage = "Please provide your gender")]
        [StringLength(50)]
        public string Gender { get; set; }

        [Display( Name ="Date Of Birth")]
        [Required(ErrorMessage = "Please provide your Date Of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Surburb is required")]
        [StringLength(40)]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [Display(Name = "Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Province is required")]
        [StringLength(40)]
        public string Province { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }

        [Display(Name ="Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is Required")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public int RoleId { get; set; }
        public virtual Tbl_Role Roles { get; set; }

        [Required]
        public Guid ActivationCode { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Error : Confirm password does not match with password")]
        public string ConfirmPassword { get; set; }



    }
}