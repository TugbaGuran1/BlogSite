using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.Model
{
    [Table("KullaniciMesaj")]
    public class KullaniciMesaj
    {
       
            [Key]

            public int? MessageID { get; set; }

            public string Konu { get; set; }

            public string Mesaj { get; set; }

            public string Eposta { get; set; }
            public string AdSoyad { get; set; }

      
    }
}