using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EkinKececiBlogSite.Models.DataContext;
using EkinKececiBlogSite.Models.Model;

namespace EkinKececiBlogSite.Controllers
{
    public class KullaniciMesajController : Controller
    {
        private EkinDBContext db = new EkinDBContext();

        // GET: KullaniciMesaj
        public ActionResult Index()
        {
            return View(db.KullaniciMesaj.ToList());
        }

        // GET: KullaniciMesaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciMesaj kullaniciMesaj = db.KullaniciMesaj.Find(id);
            if (kullaniciMesaj == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciMesaj);
        }

        // GET: KullaniciMesaj/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageID,Konu,Mesaj,Eposta,AdSoyad")] KullaniciMesaj kullaniciMesaj)
        {
            if (ModelState.IsValid)
            {
                db.KullaniciMesaj.Add(kullaniciMesaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullaniciMesaj);
        }

        // GET: KullaniciMesaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciMesaj kullaniciMesaj = db.KullaniciMesaj.Find(id);
            if (kullaniciMesaj == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciMesaj);
        }

        // POST: KullaniciMesaj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageID,Konu,Mesaj,Eposta,AdSoyad")] KullaniciMesaj kullaniciMesaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullaniciMesaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullaniciMesaj);
        }

        // GET: KullaniciMesaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciMesaj kullaniciMesaj = db.KullaniciMesaj.Find(id);
            if (kullaniciMesaj == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciMesaj);
        }

        // POST: KullaniciMesaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KullaniciMesaj kullaniciMesaj = db.KullaniciMesaj.Find(id);
            db.KullaniciMesaj.Remove(kullaniciMesaj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
