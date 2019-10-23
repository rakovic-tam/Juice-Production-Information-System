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
    public class IzvestajOStanjuRepromaterijalasController : Controller
    {
        private ISBahusEntities db = new ISBahusEntities();
      

        public static IzvestajOStanjuRepromaterijala izvestaj;

        // GET: IzvestajOStanjuRepromaterijalas
        public ActionResult Index()
        {
                    
            return View(db.IzvestajOStanjuRepromaterijalas.Include(x => x.StavkeIzvestajaOStanjuRepromaterijalas.Select(t => t.IzvestajOStanjuRepromaterijala)).ToList());
        }

        // GET: IzvestajOStanjuRepromaterijalas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            izvestaj = db.IzvestajOStanjuRepromaterijalas.Find(id);
            int i = 1;
            foreach (StavkeIzvestajaOStanjuRepromaterijala s in izvestaj.StavkeIzvestajaOStanjuRepromaterijalas)
            {
                s.RedniBroj = i;
                i++;
            }
            if (izvestaj == null)
            {
                return HttpNotFound();
            }
            return View(izvestaj);
        }

        // GET: IzvestajOStanjuRepromaterijalas/Create
        public ActionResult Create()
        {
            if (izvestaj == null) {

                izvestaj = new IzvestajOStanjuRepromaterijala();
                try
                {
                    izvestaj.SifraIzvestaja = db.IzvestajOStanjuRepromaterijalas.Max(x => x.SifraIzvestaja) + 1;
                    izvestaj.Datum = DateTime.Now;
                }
                catch (Exception)
                {

                    izvestaj.SifraIzvestaja = 1;
                }
                izvestaj.Status = Status.Nov;


            }
            ViewBag.Prima = new SelectList(db.Radniks, "SifraRadnika", "PunoIme");
            ViewBag.Izdaje = new SelectList(db.Radniks, "SifraRadnika", "PunoIme");
            ViewBag.SifraZahteva = new SelectList(db.ZahtevOStanjuRepromaterijalas, "SifraZahteva", "TekstZahteva");
            return View(izvestaj);
        }

        // POST: IzvestajOStanjuRepromaterijalas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Datum,SifraZahteva,Prima,Izdaje")] IzvestajOStanjuRepromaterijala izvestajOStanjuRepromaterijala)
        {
            if (ModelState.IsValid)
            {

                foreach (StavkeIzvestajaOStanjuRepromaterijala si in izvestaj.StavkeIzvestajaOStanjuRepromaterijalas)
                {
                    si.IzvestajOStanjuRepromaterijala = null;
                    si.Sirovina = null;
                }
                izvestajOStanjuRepromaterijala.StavkeIzvestajaOStanjuRepromaterijalas = izvestaj.StavkeIzvestajaOStanjuRepromaterijalas;
                izvestajOStanjuRepromaterijala.SifraIzvestaja = izvestaj.SifraIzvestaja;
                db.IzvestajOStanjuRepromaterijalas.Add(izvestajOStanjuRepromaterijala);
                db.SaveChanges();
                izvestaj = null;
                return RedirectToAction("Index");
            }

            ViewBag.Prima = new SelectList(db.Radniks, "SifraRadnika", "PunoIme", izvestajOStanjuRepromaterijala.Prima);
            ViewBag.Izdaje = new SelectList(db.Radniks, "SifraRadnika", "PunoIme", izvestajOStanjuRepromaterijala.Izdaje);
            ViewBag.SifraZahteva = new SelectList(db.ZahtevOStanjuRepromaterijalas, "SifraZahteva", "TekstZahteva", izvestajOStanjuRepromaterijala.SifraZahteva);
            return View(izvestajOStanjuRepromaterijala);
        }

        // GET: IzvestajOStanjuRepromaterijalas/Edit/5
        public ActionResult Edit(int? id)
        {
           
            if (izvestaj == null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                izvestaj = db.IzvestajOStanjuRepromaterijalas.Find(id);
            }
            if (izvestaj == null)
            {
                return HttpNotFound();
            }
            ViewBag.Prima = new SelectList(db.Radniks, "SifraRadnika", "PunoIme", izvestaj.Prima);
            ViewBag.Izdaje = new SelectList(db.Radniks, "SifraRadnika", "PunoIme", izvestaj.Izdaje);
            ViewBag.SifraZahteva = new SelectList(db.ZahtevOStanjuRepromaterijalas, "SifraZahteva", "TekstZahteva", izvestaj.SifraZahteva);
            izvestaj.Status = Status.Izmenjen;
            return View(izvestaj);
        }

        // POST: IzvestajOStanjuRepromaterijalas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SifraIzvestaja,Datum,SifraZahteva,Prima,Izdaje")] IzvestajOStanjuRepromaterijala izvestajOStanjuRepromaterijala)
        {
            if (ModelState.IsValid)
            {
                izvestajOStanjuRepromaterijala.StavkeIzvestajaOStanjuRepromaterijalas = null;
                db.Entry(izvestajOStanjuRepromaterijala).State = EntityState.Modified;
                var stavke = db.StavkeIzvestajaOStanjuRepromaterijalas.Where(x => x.SifraIzvestaja == izvestaj.SifraIzvestaja);
                db.StavkeIzvestajaOStanjuRepromaterijalas.RemoveRange(stavke);
                foreach (StavkeIzvestajaOStanjuRepromaterijala si in izvestaj.StavkeIzvestajaOStanjuRepromaterijalas)
                {
                    si.IzvestajOStanjuRepromaterijala = null;
                    si.Sirovina = null;
                }
                db.StavkeIzvestajaOStanjuRepromaterijalas.AddRange(izvestaj.StavkeIzvestajaOStanjuRepromaterijalas);
                db.SaveChanges();
                izvestaj = null;
                return RedirectToAction("Index");
            }
            ViewBag.Prima = new SelectList(db.Radniks, "SifraRadnika", "PunoIme", izvestajOStanjuRepromaterijala.Prima);
            ViewBag.Izdaje = new SelectList(db.Radniks, "SifraRadnika", "PunoIme", izvestajOStanjuRepromaterijala.Izdaje);
            ViewBag.SifraZahteva = new SelectList(db.ZahtevOStanjuRepromaterijalas, "SifraZahteva", "TekstZahteva", izvestajOStanjuRepromaterijala.SifraZahteva);
            return View(izvestajOStanjuRepromaterijala);
        }

        // GET: IzvestajOStanjuRepromaterijalas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (izvestaj == null) izvestaj = db.IzvestajOStanjuRepromaterijalas.Find(id);
            if (izvestaj == null)
            {
                return HttpNotFound();
            }
            return View(izvestaj);
        }

        // POST: IzvestajOStanjuRepromaterijalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IzvestajOStanjuRepromaterijala izvestaj = db.IzvestajOStanjuRepromaterijalas.Find(id);
            db.IzvestajOStanjuRepromaterijalas.Remove(izvestaj);
            db.SaveChanges();
            izvestaj = null;
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

        //Stavka izvestaja o repromaterijalu

        // GET: StavkeIzvestajaOStanjuRepromaterijalas/Create
        public ActionResult CreateStavka()
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
        public ActionResult CreateStavka([Bind(Include = "SifraIzvestaja,RedniBroj,Kolicina,Napomena,SifraSirovine")] StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala)
        {
            if (ModelState.IsValid)
            {
                stavkeIzvestajaOStanjuRepromaterijala.Sirovina = db.Sirovinas.Find(stavkeIzvestajaOStanjuRepromaterijala.SifraSirovine);
                stavkeIzvestajaOStanjuRepromaterijala.IzvestajOStanjuRepromaterijala = izvestaj;
                izvestaj.dodajStavku(stavkeIzvestajaOStanjuRepromaterijala);

                switch (izvestaj.Status)
                {
                    
                    case Status.Nov:
                        return RedirectToAction("Create");                        
                    case Status.Izmenjen:
                        return RedirectToAction("Edit");

                }
            }

            ViewBag.SifraIzvestaja = new SelectList(db.IzvestajOStanjuRepromaterijalas, "SifraIzvestaja", "SifraIzvestaja", stavkeIzvestajaOStanjuRepromaterijala.SifraIzvestaja);
            ViewBag.SifraSirovine = new SelectList(db.Sirovinas, "SifraSirovine", "Naziv", stavkeIzvestajaOStanjuRepromaterijala.SifraSirovine);
            return View(stavkeIzvestajaOStanjuRepromaterijala);
        }

        // GET: StavkeIzvestajaOStanjuRepromaterijalas/Details/5
        public ActionResult DetailsStavka(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala = izvestaj.StavkeIzvestajaOStanjuRepromaterijalas.First(x => x.RedniBroj == id);
            if (stavkeIzvestajaOStanjuRepromaterijala == null)
            {
                return HttpNotFound();
            }
            return View(stavkeIzvestajaOStanjuRepromaterijala);
        }

        // GET: StavkeIzvestajaOStanjuRepromaterijalas/Edit/5
        public ActionResult EditStavka(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala = izvestaj.StavkeIzvestajaOStanjuRepromaterijalas.First(x => x.RedniBroj == id);
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
        public ActionResult EditStavka([Bind(Include = "SifraIzvestaja,RedniBroj,Kolicina,Napomena,SifraSirovine")] StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala)
        {
            if (ModelState.IsValid)
            {
                stavkeIzvestajaOStanjuRepromaterijala.Sirovina = db.Sirovinas.Find(stavkeIzvestajaOStanjuRepromaterijala.SifraSirovine);
                izvestaj.izmeniStavku(stavkeIzvestajaOStanjuRepromaterijala);
                switch (izvestaj.Status)
                {
                    case Status.Nov:
                        return RedirectToAction("Create");
                    case Status.Izmenjen:
                        return RedirectToAction("Edit");
                }
            }
            ViewBag.SifraIzvestaja = new SelectList(db.IzvestajOStanjuRepromaterijalas, "SifraIzvestaja", "SifraIzvestaja", stavkeIzvestajaOStanjuRepromaterijala.SifraIzvestaja);
            ViewBag.SifraSirovine = new SelectList(db.Sirovinas, "SifraSirovine", "Naziv", stavkeIzvestajaOStanjuRepromaterijala.SifraSirovine);
            return View(stavkeIzvestajaOStanjuRepromaterijala);
        }

        // GET: StavkeIzvestajaOStanjuRepromaterijalas/Delete/5
        public ActionResult DeleteStavka(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeIzvestajaOStanjuRepromaterijala stavkeIzvestajaOStanjuRepromaterijala = izvestaj.StavkeIzvestajaOStanjuRepromaterijalas.FirstOrDefault(x=>x.RedniBroj ==id);
            if (stavkeIzvestajaOStanjuRepromaterijala == null)
            {
                return HttpNotFound();
            }
            return View(stavkeIzvestajaOStanjuRepromaterijala);
        }

        // POST: StavkeIzvestajaOStanjuRepromaterijalas/Delete/5
        [HttpPost, ActionName("DeleteStavka")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedStavka(int id)
        {
           
            izvestaj.obrisiStavku(id);
                switch (izvestaj.Status)
            {

                case Status.Nov:
                    return RedirectToAction("Create");
                case Status.Izmenjen:
                    return RedirectToAction("Edit");

            }

        

            return View(izvestaj);
        }
    }
}
