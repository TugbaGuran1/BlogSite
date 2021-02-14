using EkinKececiBlogSite.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.DataContext
{
    public class EkinDBContext:DbContext
    {
        public EkinDBContext():base("EkinKececiDB")
        {
                
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Kimlik> Kimlik { get; set; }
        public DbSet<Proje> Proje { get; set; }
        public DbSet<KullaniciMesaj> KullaniciMesaj { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
        public DbSet<YorumEN> YorumEN { get; set; }
        public DbSet<KategoriEN> KategoriEN { get; set; }
        public DbSet<BlogEN> BlogEN { get; set; }
        public DbSet<KullaniciMesajEN> KullaniciMesajEN { get; set; }
        public DbSet<AdminEN> AdminEN { get; set; }
        public DbSet<SliderEN> SliderEN { get; set; }
        public DbSet<Logs> Logs { get; set; }
        
    }
}