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
    public class SirovinasController : Controller
    {
        private ISBahusEntities db = new ISBahusEntities();

        // GET: Sirovinas
        public ActionResult Index()
        {
            return View(db.Sirovinas.ToList());
        }

        // GET: Sirovinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirovina sirovina = db.Sirovinas.Find(id);
            if (sirovina == null)
            {
                return HttpNotFound();
            }
            return View(sirovina);
        }

        // GET: Sirovinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sirovinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SifraSirovine,Naziv")] Sirovina sirovina)
        {
            if (ModelState.IsValid)
            {
                db.Sirovinas.Add(sirovina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sirovina);
        }

        // GET: Sirovinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirovina sirovina = db.Sirovinas.Find(id);
            if (sirovina == null)
            {
                return HttpNotFound();
            }
            return View(sirovina);
        }

        // POST: Sirovinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SifraSirovine,Naziv")] Sirovina sirovina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sirovina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sirovina);
        }

        // GET: Sirovinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirovina sirovina = db.Sirovinas.Find(id);
            if (sirovina == null)
            {
                return HttpNotFound();
            }
            return View(sirovina);
        }

        // POST: Sirovinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sirovina sirovina = db.Sirovinas.Find(id);
            db.Sirovinas.Remove(sirovina);
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
