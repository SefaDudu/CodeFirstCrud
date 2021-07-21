using CodeFirst_Ef.Models;
using CodeFirst_Ef.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_Ef.Controllers
{
    public class KisiController : Controller
    {

        // GET: Kisi
        DatabaseContext db = new DatabaseContext();
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Kisiler k)
        {
           
            db.Kisiler.Add(k);
            int s =db.SaveChanges();
            if (s>0)
            {
                ViewBag.Result = "Kişi Kaydedilmiştir.";
                ViewBag.Status = "Success";

            }
            else
            {

                ViewBag.Result = "Kisi Kaydedilememiştir.";
                ViewBag.Status = "danger";
            }
            return View();
        }
        public ActionResult Duzenle(int? kisiid)
        {
            Kisiler k = null;
            if (kisiid != null)
            {
                k = db.Kisiler.Where(x => x.Id == kisiid).FirstOrDefault();

            }
            return View(k);

        }
        [HttpPost]
        public ActionResult Duzenle(Kisiler model, int? kisiid)
        {
          
              Kisiler  k = db.Kisiler.Where(x => x.Id ==kisiid).FirstOrDefault();

            if (k != null)
            {
                k.Ad = model.Ad;
                k.Soyad = model.Soyad;
                k.Yas = model.Yas;
              int sonuc=  db.SaveChanges();
                if (sonuc > 0)
                {
                    ViewBag.Result = "Kişi Güncellendi.";
                    ViewBag.Status = "Success";

                }
                else
                {

                    ViewBag.Result = "Kisi Güncellenememiştir.";
                    ViewBag.Status = "danger";
                }
            }
            return View();
        }
       
        public ActionResult Sil(int? id)
        {
            var b = db.Kisiler.Find(id);
            db.Kisiler.Remove(b);
            db.SaveChanges();
            return RedirectToAction("homepage","Home");

        }

    }
}