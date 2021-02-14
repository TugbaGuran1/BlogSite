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
    public class YorumsController : Controller
    {
        private EkinDBContext db = new EkinDBContext();

        // GET: Yorums
        public ActionResult Index()
        {
            var yorums = db.Yorums.Include(y => y.Blog);
            return View(yorums.ToList());
        }

        // GET: Yorums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorums.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // GET: Yorums/Create
        public ActionResult Create()
        {
            ViewBag.BlogId = new SelectList(db.Blog, "BlogId", "Baslik");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YorumID,AdSoyad,Eposta,Icerik,Onay,BlogId,YorumTarih,AdminCevabı,CevapTarihi")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Yorums.Add(yorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogId = new SelectList(db.Blog, "BlogId", "Baslik", yorum.BlogId);
            return View(yorum);
        }

        // GET: Yorums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorums.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(db.Blog, "BlogId", "Baslik", yorum.BlogId);
            return View(yorum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YorumID,AdSoyad,Eposta,Icerik,Onay,BlogId,YorumTarih,AdminCevabı,CevapTarihi")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogId = new SelectList(db.Blog, "BlogId", "Baslik", yorum.BlogId);
            return View(yorum);
        }

        // GET: Yorums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorums.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // POST: Yorums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yorum yorum = db.Yorums.Find(id);
            db.Yorums.Remove(yorum);
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
