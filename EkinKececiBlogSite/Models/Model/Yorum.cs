using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.Model
{
    [Table("Yorum")]
    public class Yorum
    {
        [Key]
        public int YorumID { get; set; }
        [Required, StringLength(50, ErrorMessage ="50 Karakter Olabilir.")]
        public string AdSoyad { get; set; }
        public string Eposta { get; set; }
        [DisplayName("Yorumunuz")]
        public string Icerik { get; set; }
        public bool Onay { get; set; }
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }
        public DateTime YorumTarih { get; set; }
        public string AdminCevabı { get; set; }
        public DateTime CevapTarihi { get; set; }
    }
}