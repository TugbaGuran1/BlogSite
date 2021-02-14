using EkinKececiBlogSite.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EkinKececiBlogSite.Models.Model;
using System.Threading;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using EkinKececiBlogSite.Models.Dto;
using EkinKececiBlogSite.Models.WebsiteModels;
using System.Data.Entity;


namespace EkinKececiBlogSite.Controllers
{
    public class HomeController : Controller
    {
        private EkinDBContext db = new EkinDBContext();

        public ActionResult BlogKategori(int Sayfa = 1)
        {
            try
            {

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
  
                AddLog(msg);
            }
            return View(db.Blog.Include("Kategori").Include("Yorums").OrderByDescending(x => x.BlogId).ToPagedList(Sayfa, 3));
        }

        public ActionResult Index(int Sayfa = 1)
        {

            IndexBlogModel sepet = new IndexBlogModel();

            try
            {
                string lang = "tr";
                if (Request.Cookies["Language"] != null)
                {
                    string cookie = Request.Cookies["Language"].Value;

                    if (cookie != null && cookie == "tr")
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                    }
                    else
                    {
                        lang = "en";
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
                    }
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                }
                if (lang == "tr")
                {
                    //sepet.armut = (from blogtr in db.Blog
                    //       join cat in db.Kategori on blogtr.KategoriId equals cat.KategoriId
                    //       orderby blogtr.BlogId descending
                    //       select new Blog
                    //       {
                    //           Baslik = blogtr.Baslik,
                    //           BlogId = blogtr.BlogId,
                    //           Icerik = blogtr.Icerik,
                    //           ResimURL = blogtr.ResimURL,
                    //           Kategori=blogtr.Kategori,
                    //           KategoriId=blogtr.KategoriId
                    //          //Kategori=blogtr.Kategori,
                    //          //KategoriId=blogtr.KategoriId,
                    //       }).ToPagedList(Sayfa, 10);
                    sepet.armut = db.Blog.Include("Kategori").OrderByDescending(x => x.BlogId).ToPagedList(Sayfa, 10);
                }
                else
                {
                    sepet.elma = db.BlogEN.Include("KategoriEN").OrderByDescending(x => x.BlogId).ToPagedList(Sayfa, 10);

                    //sepet.elma = (from blogen in db.BlogEN
                    //              join cat in db.KategoriEN on blogen.KategoriIden equals cat.KategoriIden
                    //              orderby blogen.BlogId descending
                    //              select new BlogEN
                    //              {
                    //                  Baslik = blogen.Baslik,
                    //                  BlogId = blogen.BlogId,
                    //                  Icerik = blogen.Icerik,
                    //                  ResimURL = blogen.ResimURL,
                    //                  //KategoriEN=blogen.KategoriEN,
                    //                  //KategoriIden=blogen.KategoriIden,
                    //              }).ToPagedList(Sayfa, 10);

                }
                ViewBag.lang = lang;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);
            }

            return View(sepet);
        }

        public ActionResult SliderPartial()
        {
            SliderModel sepet = new SliderModel();
            try
            {
                string lang = "tr";
                if (Request.Cookies["Language"] != null)
                {
                    string cookie = Request.Cookies["Language"].Value;

                    if (cookie != null && cookie == "tr")
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                    }
                    else
                    {
                        lang = "en";
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
                    }
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                }

                if (lang == "tr")
                {


                    sepet.armut = db.Slider.ToList().OrderByDescending(x => x.SliderID).ToList();


                }
                else
                {
                    sepet.elma = db.SliderEN.ToList().OrderByDescending(x => x.SliderID).ToList();


                }
                ViewBag.lang = lang;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);
            }

            return View(sepet);
            //return View(db.Slider.ToList().OrderByDescending(x => x.SliderID));
        }

        public ActionResult ProjePartial()
        {
            return View(db.Proje.ToList().OrderByDescending(x => x.ProjeId));
        }

        public ActionResult BlogPartial(int Sayfa = 1)
        {
            IndexBlogModel sepet = new IndexBlogModel();

            try
            {
                string lang = "tr";
                if (Request.Cookies["Language"] != null)
                {
                    string cookie = Request.Cookies["Language"].Value;

                    if (cookie != null && cookie == "tr")
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                    }
                    else
                    {
                        lang = "en";
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
                    }
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                }
                if (lang == "tr")
                {


                    sepet.armut = db.Blog.Include("Kategori").OrderByDescending(x => x.BlogId).ToPagedList(Sayfa, 10);


                }
                else
                {
                    sepet.elma = db.BlogEN.Include("KategoriEN").OrderByDescending(x => x.BlogId).ToPagedList(Sayfa, 10);

                }
                ViewBag.lang = lang;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);
            }

            return View(sepet);
        }

        [Route("iletisim")]
        public ActionResult Iletisim()
        {
            try
            {
                string lang = "tr";
                if (Request.Cookies["Language"] != null)
                {
                    string cookie = Request.Cookies["Language"].Value;

                    if (cookie != null && cookie == "tr")
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                    }
                    else
                    {
                        lang = "en";
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
                    }
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);
            }

            return View(db.Iletisim.SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Iletisim(string adsoyad = null, string email = null, string konu = null, string mesaj = null)
        {
            try
            {
                if (adsoyad != null && email != null)
                {
                    db.KullaniciMesaj.Add(new KullaniciMesaj { AdSoyad = adsoyad, Eposta = email, Mesaj = mesaj, Konu = konu });
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.Uyari = "Hata Oluştu.Tekrar deneyiniz";
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);
            }
        
            return View();
        }

        [Route("BlogPost")]
        public ActionResult Blog(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);

            }
            var b = db.Blog.Include("Kategori").Include("Yorums").Where(x => x.BlogId == id).SingleOrDefault();
            return View(b);
        }

        //[Route("BlogPost")]
        //public ActionResult BlogMakaleKategori(int id, int Sayfa = 1)
        //{
        //    IPagedList<Blog> res = new List<Blog>().ToPagedList(Sayfa, 3);
        //    try
        //    {
        //        //var=res
        //        res = db.Blog.Include("Kategori").OrderByDescending(x => x.BlogId).Where(x => x.Kategori.KategoriId == id).ToPagedList(Sayfa, 3);

        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }
        //    return View(res);
        //}

        public ActionResult BlogMakaleKategori(int id, int Sayfa = 1)
        {

            IndexBlogModel sepet = new IndexBlogModel();

            try
            {
                string lang = "tr";
                if (Request.Cookies["Language"] != null)
                {
                    string cookie = Request.Cookies["Language"].Value;

                    if (cookie != null && cookie == "tr")
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                    }
                    else
                    {
                        lang = "en";
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
                    }
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                }
                if (lang == "tr")
                {
                    //sepet.armut = (from blogtr in db.Blog
                    //       join cat in db.Kategori on blogtr.KategoriId equals cat.KategoriId
                    //       orderby blogtr.BlogId descending
                    //       select new Blog
                    //       {
                    //           Baslik = blogtr.Baslik,
                    //           BlogId = blogtr.BlogId,
                    //           Icerik = blogtr.Icerik,
                    //           ResimURL = blogtr.ResimURL,
                    //           Kategori=blogtr.Kategori,
                    //           KategoriId=blogtr.KategoriId


                    //          //Kategori=blogtr.Kategori,
                    //          //KategoriId=blogtr.KategoriId,


                    //       }).ToPagedList(Sayfa, 10);

                    sepet.armut = db.Blog.Include("Kategori").OrderByDescending(x => x.BlogId).Where(x => x.Kategori.KategoriId == id).ToPagedList(Sayfa, 4);
                }
                else
                {
                    sepet.elma = db.BlogEN.Include("KategoriEN").OrderByDescending(x => x.BlogId).Where(x => x.KategoriEN.KategoriIden == id).ToPagedList(Sayfa, 4);

                    //sepet.elma = (from blogen in db.BlogEN
                    //       join cat in db.KategoriEN on blogen.KategoriIden equals cat.KategoriIden
                    //       orderby blogen.BlogId descending
                    //       select new BlogEN
                    //       {
                    //           Baslik = blogen.Baslik,
                    //           BlogId = blogen.BlogId,
                    //           Icerik = blogen.Icerik,
                    //           ResimURL = blogen.ResimURL,
                    //          //KategoriEN=blogen.KategoriEN,
                    //          //KategoriIden=blogen.KategoriIden,
                    //       }).ToPagedList(Sayfa, 10);

                }
                ViewBag.lang = lang;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);

            }

            return View(sepet);
        }

        public JsonResult YorumYap(string adsoyad, string eposta, string icerik, int blogid)
        {
            try
            {
                if (icerik == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                db.Yorums.Add(new Yorum { AdSoyad = adsoyad, Eposta = eposta, Icerik = icerik, BlogId = blogid, Onay = false, CevapTarihi = DateTime.Now, YorumTarih = DateTime.Now });
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);

            }
       
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult YorumYapEN(string adsoyad, string eposta, string icerik, int blogid)
        {
            try
            {
                if (icerik == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                db.YorumEN.Add(new YorumEN { AdSoyad = adsoyad, Eposta = eposta, Icerik = icerik, BlogId = blogid, Onay = false, CevapTarihi = DateTime.Now, YorumTarih = DateTime.Now });
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);

            }
         
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult MesajYolla(string adsoyad, string eposta, string mesaj, string konu, int mesajid)
        {
            try
            {
                if (mesaj == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                db.KullaniciMesaj.Add(new KullaniciMesaj { AdSoyad = adsoyad, Eposta = eposta, Mesaj = mesaj, Konu = konu, MessageID = mesajid });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);

            }
         

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult KategoriPartial()
        {
            BlogKategoriModel sepet = new BlogKategoriModel();

            try
            {
                string lang = "tr";
                if (Request.Cookies["Language"] != null)
                {
                    string cookie = Request.Cookies["Language"].Value;

                    if (cookie != null && cookie == "tr")
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                    }
                    else
                    {
                        lang = "en";
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
                    }
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                }
                if (lang == "tr")
                {

                    sepet.armut = db.Kategori.Include("Blogs").ToList().OrderBy(x => x.KategoriAd).ToList();


                }
                else
                {
                    sepet.elma = db.KategoriEN.Include("BlogEN").ToList().OrderBy(x => x.KategoriAd).ToList();


                }
                ViewBag.lang = lang;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;

            }


            db.Configuration.LazyLoadingEnabled = false;
            return PartialView(sepet);

            //return PartialView(db.Kategori.Include("Blogs").ToList().OrderBy(x => x.KategoriAd));
        }

        //public ActionResult KategoriGetirPartial()
        //{
        //    BlogKategoriModel sepet = new BlogKategoriModel();

        //    try
        //    {
        //        string lang = "tr";
        //        if (Request.Cookies["Language"] != null)
        //        {
        //            string cookie = Request.Cookies["Language"].Value;

        //            if (cookie != null && cookie == "tr")
        //            {
        //                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
        //                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
        //            }
        //            else
        //            {
        //                lang = "en";
        //                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
        //                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
        //            }
        //        }
        //        else
        //        {
        //            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
        //            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
        //        }

        //        if (lang == "tr")
        //        {

        //            sepet.armut = db.Kategori.Include("Blogs").ToList().GroupBy(x => x.KategoriAd).ToList();


        //        }
        //        else
        //        {
        //            sepet.elma = db.KategoriEN.Include("BlogEN").ToList().GroupBy(x => x.KategoriAd).ToList();


        //        }
        //        ViewBag.lang = lang;

        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;

        //    }

        //    return View(sepet);

        //    //db.Configuration.LazyLoadingEnabled = false;
        //    //return PartialView(db.Kategori.Include("Blogs").ToList().GroupBy(x => x.KategoriAd));



            //}
            public ActionResult KategoriNavbarPartial()
        {


            BlogKategoriModel sepet = new BlogKategoriModel();

            try
            {
                string lang = "tr";
                if (Request.Cookies["Language"] != null)
                {
                    string cookie = Request.Cookies["Language"].Value;

                    if (cookie != null && cookie == "tr")
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                    }
                    else
                    {
                        lang = "en";
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
                    }
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                }
                if (lang == "tr")
                {
                    try
                    {
                        sepet.armut = db.Kategori.Include("Blogs").ToList().OrderBy(x => x.KategoriAd).ToList();

                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        AddLog(msg);
                    }



                }
                else
                {
                    sepet.elma = db.KategoriEN.Include("BlogEN").ToList().OrderBy(x => x.KategoriAd).ToList();


                }
                ViewBag.lang = lang;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;

            }

            return PartialView(sepet);

            //db.Configuration.LazyLoadingEnabled = false;


            //return PartialView(db.Kategori.Include("Blogs").ToList().OrderBy(x => x.KategoriAd));



        }

        //    //sepet.elma = db.KategoriEN.Include("BlogEN").ToList().OrderBy(x => x.KategoriAd);


        //}

        public ActionResult BlogKayitPartial()
        {

            return PartialView(db.Blog.Take(8).ToList().OrderByDescending(x => x.BlogId));
        }

        //public ActionResult BlogDetay(int id)
        //{
        //    var b = db.Blog.Include("Kategori").Include("Yorums").Where(x => x.BlogId == id).SingleOrDefault();
        //    return View(b);
        //}

        public ActionResult BlogDetay(int id)
        {
            BlogDetayModel sepet = new BlogDetayModel();

            try
            {
                string lang = "tr";
                if (Request.Cookies["Language"] != null)
                {
                    string cookie = Request.Cookies["Language"].Value;

                    if (cookie != null && cookie == "tr")
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                    }
                    else
                    {
                        lang = "en";
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
                    }
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                }
                if (lang == "tr")
                {

                    sepet.armut = db.Blog.Include("Kategori").Include("Yorums").Where(x => x.BlogId == id).SingleOrDefault();


                }
                else
                {
                    sepet.elma = db.BlogEN.Include("KategoriEN").Include("YorumEN").Where(x => x.BlogId == id).SingleOrDefault();


                }
                ViewBag.lang = lang;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AddLog(msg);

            }

            return View(sepet);
            //var b = db.Blog.Include("Kategori").Include("Yorums").Where(x => x.BlogId == id).SingleOrDefault();
            //return View(b);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            Response.Cookies.Remove("Language");
            var langCookie = new HttpCookie("Language");
            langCookie["Language"] = lang;
            langCookie.Value = lang;
            langCookie.Expires = System.DateTime.Now.AddDays(21);
            Response.Cookies.Add(langCookie);
            if (lang == "tr")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");

            }
            return RedirectToAction("Index");
        }

        private void AddLog(string text)
        {
            Logs lg = new Logs();
            lg.LogDate = DateTime.Now;
            lg.MethodLog = text;

            db.Logs.Add(lg);
            db.SaveChanges();
        }
    }
}