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
    
    public partial class NalogZaProizvodnju
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NalogZaProizvodnju()
        {
            this.ZahtevOStanjuRepromaterijalas = new HashSet<ZahtevOStanjuRepromaterijala>();
        }
    
        public int SifraNaloga { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public Nullable<int> Prima { get; set; }
        public Nullable<int> Izdaje { get; set; }
    
        public virtual Radnik Radnik { get; set; }
        public virtual Radnik Radnik1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZahtevOStanjuRepromaterijala> ZahtevOStanjuRepromaterijalas { get; set; }
    }
}
