using CodeFirst_Ef.Models.Manager;
using CodeFirst_Ef.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_Ef.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homepage()
        {
            DatabaseContext db = new DatabaseContext();
            //var result = db.Kisiler.ToList();//select atılmış hali 
            HomePageVM model = new HomePageVM();
            model.Kisiler = db.Kisiler.ToList();
            model.Adresler = db.Adresler.ToList();
            return View(model);
        }
    }
}