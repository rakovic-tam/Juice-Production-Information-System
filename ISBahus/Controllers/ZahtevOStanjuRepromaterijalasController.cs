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
    public class ZahtevOStanjuRepromaterijalasController : Controller
    {
        private ISBahusEntities db = new ISBahusEntities();
        WebServiceZahtev wsz = new WebServiceZahtev();

        // GET: ZahtevOStanjuRepromaterijalas
        public ActionResult Index()
        {
            var zahtevOStanjuRepromaterijalas = wsz.VratiSveZahteve();
            return View(zahtevOStanjuRepromaterijalas.ToList());
        }

        // GET: ZahtevOStanjuRepromaterijalas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahtevOStanjuRepromaterijala zahtevOStanjuRepromaterijala = wsz.PronadjiZahtev((int)id);
            if (zahtevOStanjuRepromaterijala == null)
            {
                return HttpNotFound();
            }
            return View(zahtevOStanjuRepromaterijala);
        }

        // GET: ZahtevOStanjuRepromaterijalas/Create
        public ActionResult Create()
        {
            ViewBag.SifraNalogaZaProizvodnju = wsz.VratiNaloge();
            ViewBag.Izdaje = wsz.VratiRadnike();
            ViewBag.Prima = wsz.VratiRadnike();
            return View();
        }

        // POST: ZahtevOStanjuRepromaterijalas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SifraZahteva,Datum,TekstZahteva,Izdaje,Prima,SifraNalogaZaProizvodnju")] ZahtevOStanjuRepromaterijala zahtevOStanjuRepromaterijala)
        {
            if (ModelState.IsValid)
            {
                zahtevOStanjuRepromaterijala.Radnik = null;
                zahtevOStanjuRepromaterijala.Radnik1 = null;
                zahtevOStanjuRepromaterijala.NalogZaProizvodnju = null;
               
               if(wsz.SacuvajZahtev(zahtevOStanjuRepromaterijala))  return RedirectToAction("Index");
            }

            ViewBag.SifraNalogaZaProizvodnju =wsz.VratiNaloge();
            ViewBag.Izdaje = wsz.VratiSveZahteve();
            ViewBag.Prima = wsz.VratiSveZahteve();
            return View(zahtevOStanjuRepromaterijala);
        }

        // GET: ZahtevOStanjuRepromaterijalas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahtevOStanjuRepromaterijala zahtevOStanjuRepromaterijala = wsz.PronadjiZahtev((int)id);
            if (zahtevOStanjuRepromaterijala == null)
            {
                return HttpNotFound();
            }
            ViewBag.SifraNalogaZaProizvodnju = wsz.VratiNaloge();
            ViewBag.Izdaje = wsz.VratiRadnike();
            ViewBag.Prima = wsz.VratiRadnike();
            return View(zahtevOStanjuRepromaterijala);
        }

        // POST: ZahtevOStanjuRepromaterijalas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SifraZahteva,Datum,TekstZahteva,Izdaje,Prima,SifraNalogaZaProizvodnju")] ZahtevOStanjuRepromaterijala zahtevOStanjuRepromaterijala)
        {
            if (ModelState.IsValid)
            {
                zahtevOStanjuRepromaterijala.Radnik = null;
                zahtevOStanjuRepromaterijala.Radnik1 = null;
                zahtevOStanjuRepromaterijala.NalogZaProizvodnju = null;
             
                if(wsz.IzmeniZahtev(zahtevOStanjuRepromaterijala)) return RedirectToAction("Index");
            }
            ViewBag.SifraNalogaZaProizvodnju = wsz.VratiNaloge();
            ViewBag.Izdaje = wsz.VratiRadnike();
            ViewBag.Prima = wsz.VratiRadnike();
            return View(zahtevOStanjuRepromaterijala);
        }

        // GET: ZahtevOStanjuRepromaterijalas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahtevOStanjuRepromaterijala zahtevOStanjuRepromaterijala = wsz.PronadjiZahtev((int)id);
            if (zahtevOStanjuRepromaterijala == null)
            {
                return HttpNotFound();
            }
            return View(zahtevOStanjuRepromaterijala);
        }

        // POST: ZahtevOStanjuRepromaterijalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wsz.ObrisiZahtev((int)id);
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
