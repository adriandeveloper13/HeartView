//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthView.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pacienti:Interfaces.IModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacienti()
        {
            this.ActivitatePacienti = new HashSet<ActivitatePacienti>();
            this.Recomandari = new HashSet<Recomandari>();
        }
    
        public string NumePacient { get; set; }
        public string PrenumePacient { get; set; }
        public decimal CNP { get; set; }
        public int Varsta { get; set; }
        public string Adresa { get; set; }
        public decimal Telefon { get; set; }
        public string Email { get; set; }
        public string Ocupatie { get; set; }
        public System.Guid IDPacient { get; set; }
        public string Status { get; set; }
        public System.Guid IDDoctor { get; set; }
        public string BadgeCode { get; set; }
        public string AspNetUserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivitatePacienti> ActivitatePacienti { get; set; }
        public virtual Doctori Doctori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recomandari> Recomandari { get; set; }
    }
}
