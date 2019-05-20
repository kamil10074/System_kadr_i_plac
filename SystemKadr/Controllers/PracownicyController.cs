﻿using System;
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
    public class PracownicyController : Controller
    {
        private KadryDBEntities db = new KadryDBEntities();

        // GET: Pracownicy
        public ActionResult Index()
        {
            var pracownicy = db.Pracownicy.Include(p => p.Role).Include(p => p.Wydzialy);
            return View(pracownicy.ToList());
        }

        // GET: Pracownicy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            return View(pracownicy);
        }

        // GET: Pracownicy/Create
        public ActionResult Create()
        {
            ViewBag.Rola = new SelectList(db.Role, "Id_rola", "Rola");
            ViewBag.Wydzial = new SelectList(db.Wydzialy, "Id_wydzialu", "Wydzial");
            return View();
        }

        // POST: Pracownicy/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identyfikator,Imie,Nazwisko,PESEL,Wydzial,Stawka_zaszeregowana,Rodzaj_umowy,Data_podjecia_pracy,Miejscowosc,Rola")] Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                db.Pracownicy.Add(pracownicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Rola = new SelectList(db.Role, "Id_rola", "Rola", pracownicy.Rola);
            ViewBag.Wydzial = new SelectList(db.Wydzialy, "Id_wydzialu", "Wydzial", pracownicy.Wydzial);
            return View(pracownicy);
        }

        // GET: Pracownicy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rola = new SelectList(db.Role, "Id_rola", "Rola", pracownicy.Rola);
            ViewBag.Wydzial = new SelectList(db.Wydzialy, "Id_wydzialu", "Wydzial", pracownicy.Wydzial);
            return View(pracownicy);
        }

        // POST: Pracownicy/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identyfikator,Imie,Nazwisko,PESEL,Wydzial,Stawka_zaszeregowana,Rodzaj_umowy,Data_podjecia_pracy,Miejscowosc,Rola")] Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rola = new SelectList(db.Role, "Id_rola", "Rola", pracownicy.Rola);
            ViewBag.Wydzial = new SelectList(db.Wydzialy, "Id_wydzialu", "Wydzial", pracownicy.Wydzial);
            return View(pracownicy);
        }

        // GET: Pracownicy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            return View(pracownicy);
        }

        // POST: Pracownicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            db.Pracownicy.Remove(pracownicy);
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
