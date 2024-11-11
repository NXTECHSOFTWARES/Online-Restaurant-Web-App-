using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewProject.Models 
{ 
    public class Tbl_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [StringLength(50)]
        public string Gender { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string Suburb { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(40)]
        public string Province { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivationCode { get; set; }
        public int RoleId { get; set; }
        public virtual ICollection<Tbl_Role> Roles { get; set; }

    }
}