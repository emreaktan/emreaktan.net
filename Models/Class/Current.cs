using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Class
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Yazabilirsiniz")]
        public string CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu Alanı Boş Geçemezsiniz")]
        public string CurrentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string CurrentTittle { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrrentMail { get; set; }
        public bool Status { get; set; }
        public ICollection<SaleTransaction> Saletransactions { get; set; }
    }
}