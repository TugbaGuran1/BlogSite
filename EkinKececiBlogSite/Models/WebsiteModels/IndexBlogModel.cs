
using EkinKececiBlogSite.Models.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkinKececiBlogSite.Models.WebsiteModels
{
    public class IndexBlogModel
    {
        public IPagedList<BlogEN> elma { get; set; }
        public IPagedList<Blog> armut { get; set; }
    }
}