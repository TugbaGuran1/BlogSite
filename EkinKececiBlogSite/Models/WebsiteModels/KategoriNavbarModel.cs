using EkinKececiBlogSite.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.WebsiteModels
{
    public class KategoriNavbarModel
    {
        //public IEnumerable<KategoriEN> elma { get; set; }
        //public IEnumerable<Kategori> armut { get; set; }
        public List<KategoriEN> elma { get; set; }
        public List <Kategori> armut { get; set; }
        public List<Blog> armutblog { get; set; }
        public List<BlogEN> elmablog { get; set; }
    }
}