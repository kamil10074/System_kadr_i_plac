using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemKadr.Models;

namespace SystemKadr.Controllers
{
    public class Godziny_przepracowaneController : Controller
    {
        private KadryDBEntities db = new KadryDBEntities();

        // GET: Godziny_przepracowane
        public ActionResult Index()
        {
            var godziny_przepracowane = db.Godziny_przepracowane.Include(g => g.Pracownicy);
            return View(godziny_przepracowane.ToList());
        }

        // GET: Godziny_przepracowane/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godziny_przepracowane godziny_przepracowane = db.Godziny_przepracowane.Find(id);
            if (godziny_przepracowane == null)
            {
                return HttpNotFound();
            }
            return View(godziny_przepracowane);
        }

        // GET: Godziny_przepracowane/Create
        public ActionResult Create()
        {
            ViewBag.Identyfikator = new SelectList(db.Pracownicy, "Identyfikator", "Imie");
            return View();
        }

        // POST: Godziny_przepracowane/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_wpisu,Identyfikator,Data,Godziny")] Godziny_przepracowane godziny_przepracowane)
        {
            if (ModelState.IsValid)
            {
                db.Godziny_przepracowane.Add(godziny_przepracowane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Identyfikator = new SelectList(db.Pracownicy, "Identyfikator", "Imie", godziny_przepracowane.Identyfikator);
            return View(godziny_przepracowane);
        }

        // GET: Godziny_przepracowane/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godziny_przepracowane godziny_przepracowane = db.Godziny_przepracowane.Find(id);
            if (godziny_przepracowane == null)
            {
                return HttpNotFound();
            }
            ViewBag.Identyfikator = new SelectList(db.Pracownicy, "Identyfikator", "Imie", godziny_przepracowane.Identyfikator);
            return View(godziny_przepracowane);
        }

        // POST: Godziny_przepracowane/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_wpisu,Identyfikator,Data,Godziny")] Godziny_przepracowane godziny_przepracowane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(godziny_przepracowane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Identyfikator = new SelectList(db.Pracownicy, "Identyfikator", "Imie", godziny_przepracowane.Identyfikator);
            return View(godziny_przepracowane);
        }

        // GET: Godziny_przepracowane/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godziny_przepracowane godziny_przepracowane = db.Godziny_przepracowane.Find(id);
            if (godziny_przepracowane == null)
            {
                return HttpNotFound();
            }
            return View(godziny_przepracowane);
        }

        // POST: Godziny_przepracowane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Godziny_przepracowane godziny_przepracowane = db.Godziny_przepracowane.Find(id);
            db.Godziny_przepracowane.Remove(godziny_przepracowane);
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
