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
    public class YorumENController : Controller
    {
        private EkinDBContext db = new EkinDBContext();

        // GET: YorumEN
        public ActionResult Index()
        {
            var yorumEN = db.YorumEN.Include(y => y.BlogEN);
            return View(yorumEN.ToList());
        }

        // GET: YorumEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YorumEN yorumEN = db.YorumEN.Find(id);
            if (yorumEN == null)
            {
                return HttpNotFound();
            }
            return View(yorumEN);
        }

        // GET: YorumEN/Create
        public ActionResult Create()
        {
            ViewBag.BlogId = new SelectList(db.BlogEN, "BlogId", "Baslik");
            return View();
        }

        // POST: YorumEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YorumID,AdSoyad,Eposta,Icerik,Onay,BlogId,YorumTarih,AdminCevabı,CevapTarihi")] YorumEN yorumEN)
        {
            if (ModelState.IsValid)
            {
                db.YorumEN.Add(yorumEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogId = new SelectList(db.BlogEN, "BlogId", "Baslik", yorumEN.BlogId);
            return View(yorumEN);
        }

        // GET: YorumEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YorumEN yorumEN = db.YorumEN.Find(id);
            if (yorumEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(db.BlogEN, "BlogId", "Baslik", yorumEN.BlogId);
            return View(yorumEN);
        }

        // POST: YorumEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YorumID,AdSoyad,Eposta,Icerik,Onay,BlogId,YorumTarih,AdminCevabı,CevapTarihi")] YorumEN yorumEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorumEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogId = new SelectList(db.BlogEN, "BlogId", "Baslik", yorumEN.BlogId);
            return View(yorumEN);
        }

        // GET: YorumEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YorumEN yorumEN = db.YorumEN.Find(id);
            if (yorumEN == null)
            {
                return HttpNotFound();
            }
            return View(yorumEN);
        }

        // POST: YorumEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YorumEN yorumEN = db.YorumEN.Find(id);
            db.YorumEN.Remove(yorumEN);
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
