using EkinKececiBlogSite.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.Dto
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string ResimURL { get; set; }

        //KATEGORİ
        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }
        public string Aciklama { get; set; }
    }
}