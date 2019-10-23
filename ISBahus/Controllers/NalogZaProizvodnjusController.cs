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
    public class NalogZaProizvodnjusController : Controller
    {
        private ISBahusEntities db = new ISBahusEntities();

        // GET: NalogZaProizvodnjus
        public ActionResult Index()
        {
            var nalogZaProizvodnjus = db.NalogZaProizvodnjus.Include(n => n.Radnik).Include(n => n.Radnik1);
            return View(nalogZaProizvodnjus.ToList());
        }

        // GET: NalogZaProizvodnjus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NalogZaProizvodnju nalogZaProizvodnju = db.NalogZaProizvodnjus.Find(id);
            if (nalogZaProizvodnju == null)
            {
                return HttpNotFound();
            }
            return View(nalogZaProizvodnju);
        }

        // GET: NalogZaProizvodnjus/Create
        public ActionResult Create()
        {
            ViewBag.Prima = new SelectList(db.Radniks, "SifraRadnika", "Ime");
            ViewBag.Izdaje = new SelectList(db.Radniks, "SifraRadnika", "Ime");
            return View();
        }

        // POST: NalogZaProizvodnjus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SifraNaloga,Datum,Prima,Izdaje")] NalogZaProizvodnju nalogZaProizvodnju)
        {
            if (ModelState.IsValid)
            {
                db.NalogZaProizvodnjus.Add(nalogZaProizvodnju);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Prima = new SelectList(db.Radniks, "SifraRadnika", "Ime", nalogZaProizvodnju.Prima);
            ViewBag.Izdaje = new SelectList(db.Radniks, "SifraRadnika", "Ime", nalogZaProizvodnju.Izdaje);
            return View(nalogZaProizvodnju);
        }

        // GET: NalogZaProizvodnjus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NalogZaProizvodnju nalogZaProizvodnju = db.NalogZaProizvodnjus.Find(id);
            if (nalogZaProizvodnju == null)
            {
                return HttpNotFound();
            }
            ViewBag.Prima = new SelectList(db.Radniks, "SifraRadnika", "Ime", nalogZaProizvodnju.Prima);
            ViewBag.Izdaje = new SelectList(db.Radniks, "SifraRadnika", "Ime", nalogZaProizvodnju.Izdaje);
            return View(nalogZaProizvodnju);
        }

        // POST: NalogZaProizvodnjus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SifraNaloga,Datum,Prima,Izdaje")] NalogZaProizvodnju nalogZaProizvodnju)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nalogZaProizvodnju).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Prima = new SelectList(db.Radniks, "SifraRadnika", "Ime", nalogZaProizvodnju.Prima);
            ViewBag.Izdaje = new SelectList(db.Radniks, "SifraRadnika", "Ime", nalogZaProizvodnju.Izdaje);
            return View(nalogZaProizvodnju);
        }

        // GET: NalogZaProizvodnjus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NalogZaProizvodnju nalogZaProizvodnju = db.NalogZaProizvodnjus.Find(id);
            if (nalogZaProizvodnju == null)
            {
                return HttpNotFound();
            }
            return View(nalogZaProizvodnju);
        }

        // POST: NalogZaProizvodnjus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NalogZaProizvodnju nalogZaProizvodnju = db.NalogZaProizvodnjus.Find(id);
            db.NalogZaProizvodnjus.Remove(nalogZaProizvodnju);
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
