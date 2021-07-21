using CodeFirst_Ef.Models;
using CodeFirst_Ef.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_Ef.Controllers
{
    public class AdresController : Controller
    {
        // GET: Adres
        DatabaseContext db = new DatabaseContext();
        public ActionResult Yeni()
        {
          
            List<Kisiler> kisiler = db.Kisiler.ToList();
            List<SelectListItem> kisilist = new List<SelectListItem>();
            foreach (Kisiler kisi in kisiler)
            {
                SelectListItem item = new SelectListItem();
                item.Text = kisi.Ad + " " + kisi.Soyad;
                item.Value = kisi.Id.ToString();
                kisilist.Add(item);
            }
            TempData["kisiler"] = kisilist;
            ViewBag.kisiler = kisilist;
            return View();
        }
       [HttpPost]
        public ActionResult Yeni(Adresler a)
        {
            Kisiler k = db.Kisiler.Where(x => x.Id == a.Kisi.Id).FirstOrDefault();
            if (k!=null)
            {
                a.Kisi = k;
                db.Adresler.Add(a);
                int s = db.SaveChanges();
                if (s > 0)
                {
                    ViewBag.Result = "Adres Kaydedilmiştir.";
                    ViewBag.Status = "Success";

                }
                else
                {

                    ViewBag.Result = "Adres Kaydedilememiştir.";
                    ViewBag.Status = "danger";
                }
            }
            ViewBag.kisiler = TempData["kisiler"];
            return View();
        }
        public ActionResult Duzenle(int? adresid)
        {
            Adresler a = null;
            if (adresid!=null)
            {
                List<Kisiler> kisiler = db.Kisiler.ToList();
                List<SelectListItem> kisilist = new List<SelectListItem>();
                foreach (Kisiler kisi in kisiler)
                {
                    SelectListItem item = new SelectListItem();
                    item.Text = kisi.Ad + " " + kisi.Soyad;
                    item.Value = kisi.Id.ToString();
                    kisilist.Add(item);
                }
                TempData["kisiler"] = kisilist;
                ViewBag.kisiler = kisilist;
                 a = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();

                

            }
            return View(a);

        }
        [HttpPost]
        public ActionResult Duzenle(Adresler model, int? adresid)
        {
            Kisiler kisi = db.Kisiler.Where(x => x.Id == model.Kisi.Id).FirstOrDefault();
            Adresler adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();

            if (kisi != null)
            {
                adres.Kisi = kisi;
                adres.AdresTanım = model.AdresTanım;
             
                
                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    ViewBag.Result = "Adres Güncellendi.";
                    ViewBag.Status = "Success";

                }
                else
                {

                    ViewBag.Result = "Adres Güncellenememiştir.";
                    ViewBag.Status = "danger";
                }
            }
            ViewBag.kisiler = TempData["kisiler"];
            return View();
        }
        public ActionResult Sil(int? id)
        {
            var b = db.Adresler.Find(id);
            db.Adresler.Remove(b);
            db.SaveChanges();
            return RedirectToAction("homepage", "Home");

        }
    }
}