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
    public class KategoriENController : Controller
    {
        private EkinDBContext db = new EkinDBContext();

        // GET: KategoriEN
        public ActionResult Index()
        {
            return View(db.KategoriEN.ToList());
        }

        // GET: KategoriEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriEN kategoriEN = db.KategoriEN.Find(id);
            if (kategoriEN == null)
            {
                return HttpNotFound();
            }
            return View(kategoriEN);
        }

        // GET: KategoriEN/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategoriIden,KategoriAd,Aciklama")] KategoriEN kategoriEN)
        {
            if (ModelState.IsValid)
            {
                db.KategoriEN.Add(kategoriEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoriEN);
        }

        // GET: KategoriEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriEN kategoriEN = db.KategoriEN.Find(id);
            if (kategoriEN == null)
            {
                return HttpNotFound();
            }
            return View(kategoriEN);
        }

        // POST: KategoriEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategoriIden,KategoriAd,Aciklama")] KategoriEN kategoriEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoriEN);
        }

        // GET: KategoriEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriEN kategoriEN = db.KategoriEN.Find(id);
            if (kategoriEN == null)
            {
                return HttpNotFound();
            }
            return View(kategoriEN);
        }

        // POST: KategoriEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategoriEN kategoriEN = db.KategoriEN.Find(id);
            db.KategoriEN.Remove(kategoriEN);
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
