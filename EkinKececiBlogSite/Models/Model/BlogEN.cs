using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.Model
{
    [Table("BlogEN")]
    public class BlogEN
    {
        [Key]
        public int BlogId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string ResimURL { get; set; }

        public int? KategoriIden { get; set; }
        public KategoriEN KategoriEN { get; set; }
        public ICollection<YorumEN> YorumEN { get; set; }
        //public int BlogIdEN { get; set; }
        //public string Baslik { get; set; }
        //public string Icerik { get; set; }
        //public string ResimURL { get; set; }
        //public int? KategoriIden { get; set; }
        //public KategoriEN KategoriEN { get; set; }
        //public ICollection<YorumEN> YorumEN { get; set; }
    }
}