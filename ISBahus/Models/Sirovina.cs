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
    
    public partial class Sirovina
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sirovina()
        {
            this.StavkeIzvestajaOStanjuRepromaterijalas = new HashSet<StavkeIzvestajaOStanjuRepromaterijala>();
        }
    
        public int SifraSirovine { get; set; }
        public string Naziv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkeIzvestajaOStanjuRepromaterijala> StavkeIzvestajaOStanjuRepromaterijalas { get; set; }
    }
}
