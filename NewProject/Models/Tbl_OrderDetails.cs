using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class Tbl_OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public virtual Tbl_Order Order { get; set; }

        public string Username { get; set; }

        public int ProductId { get; set; }

        public virtual Tbl_Product Product { get; set; }
        public int Quantity { get; set; }

        public double? UnitPrice { get; set; }
    }
}