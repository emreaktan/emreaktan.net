using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Class
{
    public class SaleTransaction
    {
        [Key]
        public int TransactionID { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int CurrentID { get; set; }
        public virtual Current Current { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

    }
}