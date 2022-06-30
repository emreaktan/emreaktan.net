using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Class
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation  { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoices { get; set; }

        public bool Status { get; set; }
    }
}