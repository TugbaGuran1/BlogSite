using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.Model
{
    [Table("KategorEN")]
    public class KategoriEN
    {
        [Key]
        public int KategoriIden { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır.")]
        public string KategoriAd { get; set; }
        public string Aciklama { get; set; }
        public ICollection<BlogEN> BlogEN { get; set; }
    }
}