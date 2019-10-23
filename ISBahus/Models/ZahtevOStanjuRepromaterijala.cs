//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISBahus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class ZahtevOStanjuRepromaterijala
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZahtevOStanjuRepromaterijala()
        {
            this.IzvestajOStanjuRepromaterijalas = new HashSet<IzvestajOStanjuRepromaterijala>();
        }

        [DisplayName("�ifra zahteva o stanju repromaterijala")]
        public int SifraZahteva { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        [DisplayName("Tekst zahteva")]
        public string TekstZahteva { get; set; }
        public Nullable<int> Izdaje { get; set; }
        public Nullable<int> Prima { get; set; }
        [DisplayName("�ifra naloga za proizvodnju")]
        public Nullable<int> SifraNalogaZaProizvodnju { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzvestajOStanjuRepromaterijala> IzvestajOStanjuRepromaterijalas { get; set; }
        public virtual NalogZaProizvodnju NalogZaProizvodnju { get; set; }
        public virtual Radnik Radnik { get; set; }
        public virtual Radnik Radnik1 { get; set; }
    }
}