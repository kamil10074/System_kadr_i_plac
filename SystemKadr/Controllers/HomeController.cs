using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemKadr.Models;

namespace SystemKadr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(SystemKadr.Models.Pracownicy userModel)
        {
            using (KadryDBEntities db = new KadryDBEntities())
            {
                var userDetails = db.Pracownicy.Where(x => x.Identyfikator == userModel.Identyfikator && x.PESEL == userModel.PESEL).FirstOrDefault();
                if (userDetails == null)
                {
                    return View("Index", userModel);
                }
                else
                {
                    Session["Identyfikator"] = userDetails.Identyfikator;
                    return RedirectToAction("Index", "Pracownicy");
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}