//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportskaOpremaNemanjaTutunovic.Models.EFRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Artikal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artikal()
        {
            this.StavkaPorudzbine = new HashSet<StavkaPorudzbine>();
        }
    
        public int ArtikalID { get; set; }
        public string NazivArtikla { get; set; }
        public int Cena { get; set; }
        public int idKat { get; set; }
    
        public virtual Kategorija Kategorija { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkaPorudzbine> StavkaPorudzbine { get; set; }
    }
}