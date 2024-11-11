using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class Tbl_Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name is Required")]
        [StringLength(100, ErrorMessage = "Minimum 3 and minimum 5 and maximum 100 charaters are allwed", MinimumLength = 3)]
        public string ProductName { get; set; }

        [DisplayName("Product Price")]
        [Required(ErrorMessage = "Please provide the price of the Item")]
        [Range(typeof(decimal), "1", "200000", ErrorMessage = "invalid Price")]
        public decimal Price { get; set; }

        [DisplayName("Product Destription")]
        [Required(ErrorMessage = "Product Destription is Required")]
        public string ProductDestription { get; set; }

        [Required(ErrorMessage = "Please provide the category of the Item")]
        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public virtual Tbl_Category Category { get; set; }

        [DisplayName("Product Image")]
        public string ProductImage { get; set; }

        public int numOfPurchase { get; set; }
    }
}