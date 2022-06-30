﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Class
{
    public class Admin
    {
        [Key] 
        public int AdminID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string UserName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string PassWord{ get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Authorization { get; set; }
        
    }
}