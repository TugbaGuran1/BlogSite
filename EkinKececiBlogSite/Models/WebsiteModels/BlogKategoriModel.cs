using EkinKececiBlogSite.Models.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.WebsiteModels
{
    public class BlogKategoriModel

    {
        public List<KategoriEN> elma { get; set; }
        public List<Kategori> armut { get; set; }
    }
}