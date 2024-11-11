using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class Cart
    {
        public Tbl_Product Product { get; set; }
        public int Quantity { get; set; }
        public int numOfItems { get; set; }
    }
}