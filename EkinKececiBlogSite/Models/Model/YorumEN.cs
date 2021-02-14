using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.Model
{
    [Table("YorumEN")]
    public class YorumEN
    {
        [Key]
        public int YorumID { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 Karakter Olabilir.")]
        public string AdSoyad { get; set; }
        public string Eposta { get; set; }
        public string Icerik { get; set; }
        public bool Onay { get; set; }
        public int? BlogId { get; set; }
        public BlogEN BlogEN { get; set; }
        public DateTime YorumTarih { get; set; }
        public string AdminCevabı { get; set; }
        public DateTime CevapTarihi { get; set; }
    }
}