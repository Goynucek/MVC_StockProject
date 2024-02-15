using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCsecondProject.Models.Entity;

namespace MVCsecondProject.Controllers
{
    public class UrunlerController : Controller
    {
        mvcCalısmaEntities db = new mvcCalısmaEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_Urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult NewProducts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProducts(TBL_Urunler p)
        {
            db.TBL_Urunler.Add(p);
            db.SaveChanges();
            return View(p);
        }

        public ActionResult SIL(int id)
        {
            var Category = db.TBL_Urunler.Find(id);
            db.TBL_Urunler.Remove(Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult urunGetir(int id)
        {
            var kgrt = db.TBL_Urunler.Find(id);
            return View("urunGetir", kgrt);
        }

        public ActionResult Guncelle(TBL_Urunler p1)
        {
            var kgrt = db.TBL_Urunler.Find(p1.UrunID);
            kgrt.UrunAd = p1.UrunAd;
            kgrt.Marka = p1.Marka;
            kgrt.UrunKategoriler = p1.UrunKategoriler;
            kgrt.Fiyat = p1.Fiyat;
            kgrt.Stok = p1.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}