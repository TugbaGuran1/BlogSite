﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderID { get; set; }
        [DisplayName("Slider Başlık")]
        public string Baslik { get; set; }
        [DisplayName("Slider Açıklama")]
        public string Aciklama { get; set; }
        [DisplayName("Slider Resim")]
        public string ResimURL { get; set; }
    }
}