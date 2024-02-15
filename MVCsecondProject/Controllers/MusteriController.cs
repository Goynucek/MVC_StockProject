using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCsecondProject.Models.Entity;

namespace MVCsecondProject.Controllers
{
    public class MusteriController : Controller
    {
        mvcCalısmaEntities db = new mvcCalısmaEntities();

        // GET: Musteri
        public ActionResult Index()
        {
            var degerler = db.TBL_Musteri.ToList();
            return View(degerler);
        }

        public ActionResult SIL(int id)
        {
            var musteri = db.TBL_Musteri.Find(id);
            db.TBL_Musteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(TBL_Musteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.TBL_Musteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var kgrt = db.TBL_Musteri.Find(id);
            return View("MusteriGetir", kgrt);
        }

        public ActionResult Guncelle(TBL_Musteri p1)
        {
            var kgrt = db.TBL_Musteri.Find(p1.MusteriId);
            kgrt.MusteriAd = p1.MusteriAd;
            kgrt.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}