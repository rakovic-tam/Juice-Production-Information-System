using ISBahus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Entity;
using System.Web.Mvc;

namespace ISBahus
{
    /// <summary>
    /// Summary description for WebServiceZahtev
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceZahtev : System.Web.Services.WebService
    {
        private ISBahusEntities db = new ISBahusEntities();
        
       

        [WebMethod]
        internal List<ZahtevOStanjuRepromaterijala> VratiSveZahteve()
        {
            return db.ZahtevOStanjuRepromaterijalas.Include(z => z.NalogZaProizvodnju).Include(z => z.Radnik).Include(z => z.Radnik1).ToList();
        }

        internal ZahtevOStanjuRepromaterijala PronadjiZahtev(int id)
        {
            return db.ZahtevOStanjuRepromaterijalas.Find(id);
        }

        internal dynamic VratiNaloge()
        {
            return new SelectList(db.NalogZaProizvodnjus, "SifraNaloga", "SifraNaloga");
        }

        internal dynamic VratiRadnike()
        {
            return new SelectList(db.Radniks, "SifraRadnika", "PunoIme"); 
        }

        internal bool SacuvajZahtev(ZahtevOStanjuRepromaterijala zahtevOStanjuRepromaterijala)
        {
            try
            {
                db.ZahtevOStanjuRepromaterijalas.Add(zahtevOStanjuRepromaterijala);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        internal bool IzmeniZahtev(ZahtevOStanjuRepromaterijala zahtevOStanjuRepromaterijala)
        {
            try
            {
                db.Entry(zahtevOStanjuRepromaterijala).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        internal bool ObrisiZahtev(int id)
        {
            try
            {
                ZahtevOStanjuRepromaterijala zahtevOStanjuRepromaterijala = PronadjiZahtev(id);
                db.ZahtevOStanjuRepromaterijalas.Remove(zahtevOStanjuRepromaterijala);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
