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
    public class WyplatyController : Controller
    {
        private KadryDBEntities db = new KadryDBEntities();

        // GET: Wyplaty
        public ActionResult Index()
        {
            var wyplaty = db.Wyplaty.Include(w => w.Pracownicy);
            return View(wyplaty.ToList());
        }

        // GET: Wyplaty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyplaty wyplaty = db.Wyplaty.Find(id);
            if (wyplaty == null)
            {
                return HttpNotFound();
            }
            return View(wyplaty);
        }

        // GET: Wyplaty/Create
        public ActionResult Create()
        {
            ViewBag.Identyfikator = new SelectList(db.Pracownicy, "Identyfikator", "Imie");
            return View();
        }

        // POST: Wyplaty/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_tranzakcji,Identyfikator,Miesiac,Wyplata")] Wyplaty wyplaty)
        {
            if (ModelState.IsValid)
            {
                db.Wyplaty.Add(wyplaty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Identyfikator = new SelectList(db.Pracownicy, "Identyfikator", "Imie", wyplaty.Identyfikator);
            return View(wyplaty);
        }

        // GET: Wyplaty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyplaty wyplaty = db.Wyplaty.Find(id);
            if (wyplaty == null)
            {
                return HttpNotFound();
            }
            ViewBag.Identyfikator = new SelectList(db.Pracownicy, "Identyfikator", "Imie", wyplaty.Identyfikator);
            return View(wyplaty);
        }

        // POST: Wyplaty/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_tranzakcji,Identyfikator,Miesiac,Wyplata")] Wyplaty wyplaty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wyplaty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Identyfikator = new SelectList(db.Pracownicy, "Identyfikator", "Imie", wyplaty.Identyfikator);
            return View(wyplaty);
        }

        // GET: Wyplaty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyplaty wyplaty = db.Wyplaty.Find(id);
            if (wyplaty == null)
            {
                return HttpNotFound();
            }
            return View(wyplaty);
        }

        // POST: Wyplaty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wyplaty wyplaty = db.Wyplaty.Find(id);
            db.Wyplaty.Remove(wyplaty);
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
