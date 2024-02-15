using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MVCsecondProject.Models.Entity;

namespace MVCsecondProject.Controllers
{
    public class KatergoriController : Controller
    {
        mvcCalısmaEntities db = new mvcCalısmaEntities();
        // GET: Katergori
        public ActionResult Index()
        {
            var degerler = db.TBL_Kategori.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            //List<SelectListItem> deger = (from i in db.TBL_Kategori.ToList()
            //                              select new SelectListItem
            //                              {
            //                                  Text = i.KategoriAd,
            //                                  Value = i.KategoriID.ToString()
            //                              }).ToList();
            //ViewBag.dgr = deger;
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(TBL_Kategori p)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.TBL_Kategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var Category = db.TBL_Kategori.Find(id);
            db.TBL_Kategori.Remove(Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kgrt = db.TBL_Kategori.Find(id);
            return View("KategoriGetir", kgrt);
        }

        public ActionResult Guncelle(TBL_Kategori p1)
        {
            var kgrt = db.TBL_Kategori.Find(p1.KategoriID);
            kgrt.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}