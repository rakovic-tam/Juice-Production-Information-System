using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISBahus.Models;

namespace ISBahus.Controllers
{
    public class StavkeIzvestajaOStanjuRepromaterijalasController : Controller
    {
        private ISBahusEntities db = new ISBahusEntities();
        

        // GET: StavkeIzvestajaOStanjuRepromaterijalas
        public ActionResult Index()
        {
            var stavkeIzvestajaOStanjuRepromaterijalas = db.StavkeIzvestajaOStanjuRepromaterijalas.Include(s => s.IzvestajOStanjuRepromaterijala).Include(s => s.Sirovina);
            return View(stavkeIzvestajaOStanjuRepromaterijalas.ToList());
        }

        // GET: StavkeIzvestajaOStanjuRepromaterijalas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala = db.StavkeIzvestajaOStanjuRepromaterijalas.Find(id);
            if (stavkeIzvestajaOStanjuRepromaterijala == null)
            {
                return HttpNotFound();
            }
            return View(stavkeIzvestajaOStanjuRepromaterijala);
        }

        // GET: StavkeIzvestajaOStanjuRepromaterijalas/Create
        public ActionResult Create()
        {
            ViewBag.SifraIzvestaja = new SelectList(db.IzvestajOStanjuRepromaterijalas, "SifraIzvestaja", "SifraIzvestaja");
            ViewBag.SifraSirovine = new SelectList(db.Sirovinas, "SifraSirovine", "Naziv");
            return View();
        }

        // POST: StavkeIzvestajaOStanjuRepromaterijalas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SifraIzvestaja,RedniBroj,Kolicina,Napomena,SifraSirovine")] StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala)
        {
            if (ModelState.IsValid)
            {
                db.StavkeIzvestajaOStanjuRepromaterijalas.Add(stavkeIzvestajaOStanjuRepromaterijala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SifraIzvestaja = new SelectList(db.IzvestajOStanjuRepromaterijalas, "SifraIzvestaja", "SifraIzvestaja", stavkeIzvestajaOStanjuRepromaterijala.SifraIzvestaja);
            ViewBag.SifraSirovine = new SelectList(db.Sirovinas, "SifraSirovine", "Naziv", stavkeIzvestajaOStanjuRepromaterijala.SifraSirovine);
            return View(stavkeIzvestajaOStanjuRepromaterijala);
        }

        // GET: StavkeIzvestajaOStanjuRepromaterijalas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala = db.StavkeIzvestajaOStanjuRepromaterijalas.Find(id);
            if (stavkeIzvestajaOStanjuRepromaterijala == null)
            {
                return HttpNotFound();
            }
            ViewBag.SifraIzvestaja = new SelectList(db.IzvestajOStanjuRepromaterijalas, "SifraIzvestaja", "SifraIzvestaja", stavkeIzvestajaOStanjuRepromaterijala.SifraIzvestaja);
            ViewBag.SifraSirovine = new SelectList(db.Sirovinas, "SifraSirovine", "Naziv", stavkeIzvestajaOStanjuRepromaterijala.SifraSirovine);
            return View(stavkeIzvestajaOStanjuRepromaterijala);
        }

        // POST: StavkeIzvestajaOStanjuRepromaterijalas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SifraIzvestaja,RedniBroj,Kolicina,Napomena,SifraSirovine")] StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stavkeIzvestajaOStanjuRepromaterijala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SifraIzvestaja = new SelectList(db.IzvestajOStanjuRepromaterijalas, "SifraIzvestaja", "SifraIzvestaja", stavkeIzvestajaOStanjuRepromaterijala.SifraIzvestaja);
            ViewBag.SifraSirovine = new SelectList(db.Sirovinas, "SifraSirovine", "Naziv", stavkeIzvestajaOStanjuRepromaterijala.SifraSirovine);
            return View(stavkeIzvestajaOStanjuRepromaterijala);
        }

        // GET: StavkeIzvestajaOStanjuRepromaterijalas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala = db.StavkeIzvestajaOStanjuRepromaterijalas.Find(id);
            if (stavkeIzvestajaOStanjuRepromaterijala == null)
            {
                return HttpNotFound();
            }
            return View(stavkeIzvestajaOStanjuRepromaterijala);
        }

        // POST: StavkeIzvestajaOStanjuRepromaterijalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala = db.StavkeIzvestajaOStanjuRepromaterijalas.Find(id);
            db.StavkeIzvestajaOStanjuRepromaterijalas.Remove(stavkeIzvestajaOStanjuRepromaterijala);
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
