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
    public class ProjeController : Controller
    {
        private EkinDBContext db = new EkinDBContext();

        public ActionResult Index()
        {
            return View(db.Proje.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Proje proje, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Proje/" + logoname);

                    proje.ResimURL = "/Uploads/Proje/" + logoname;
                }
                db.Proje.Add(proje);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(proje);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Hizmet Bulunamadı";
            }
            var proje = db.Proje.Find(id);
            if (proje == null)
            {
                return HttpNotFound();
            }

            return View(proje);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Proje proje, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                var h = db.Proje.Where(x => x.ProjeId == id).SingleOrDefault();
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string hizmetname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Proje/" + hizmetname);

                    h.ResimURL = "/Uploads/Proje/" + hizmetname;
                }

                h.Baslik = proje.Baslik;
                h.Aciklama = proje.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.Proje.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.Proje.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}