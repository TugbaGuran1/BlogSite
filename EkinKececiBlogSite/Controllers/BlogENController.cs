using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EkinKececiBlogSite.Models.DataContext;
using EkinKececiBlogSite.Models.Model;

namespace EkinKececiBlogSite.Controllers
{
    public class BlogENController : Controller
    {
        private EkinDBContext db = new EkinDBContext();

        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var model = db.BlogEN.Include("KategoriEN").ToList();

            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.KategoriIden = new SelectList(db.KategoriEN, "KategoriIden", "KategoriAd");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogEN blog, HttpPostedFileBase ResimURL)
        {

            if (ResimURL != null)
            {
                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName);

                string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(600, 400);
                img.Save("~/Uploads/BlogEN/" + blogimgname);

                blog.ResimURL = "/Uploads/BlogEN/" + blogimgname;
            }
            db.BlogEN.Add(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var b = db.BlogEN.Where(x => x.BlogId == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriIden = new SelectList(db.KategoriEN, "KategoriIden", "KategoriAd", b.KategoriEN);
            return View(b);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit(int id, BlogEN blog, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                var b = db.BlogEN.Where(x => x.BlogId == id).SingleOrDefault();
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(b.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(b.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/BlogEN/" + blogimgname);

                    b.ResimURL = "/Uploads/BlogEN/" + blogimgname;
                }
                b.Baslik = blog.Baslik;
                b.Icerik = blog.Icerik;
                b.KategoriIden = blog.KategoriIden;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(blog);
        }

        public ActionResult Delete(int id)
        {
            {
                var b = db.BlogEN.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                if (System.IO.File.Exists(Server.MapPath(b.ResimURL)))
                {
                    System.IO.File.Delete(Server.MapPath(b.ResimURL));
                }
                db.BlogEN.Remove(b);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }
    }
}
