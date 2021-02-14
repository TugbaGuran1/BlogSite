using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.Model
{
    [Table("Proje")]
    public class Proje
    {
        [Key]
        public int ProjeId { get; set; }
        [Required, StringLength(150,ErrorMessage ="150 Karakter Olabilir.")]
        [DisplayName("Hizmet Baslik")]
        public string Baslik { get; set; }
        [DisplayName("Hizmet Aciklama")]
        public string Aciklama { get; set; }
        [DisplayName("Hizmet Resim")]
        public string ResimURL { get; set; }
    }
}