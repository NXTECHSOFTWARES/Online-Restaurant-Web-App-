﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class Tbl_Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        
    }
}