//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthView.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivitatePacienti:Interfaces.IModel
    {
        public System.Guid IDActivitate { get; set; }
        public decimal Puls { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Umiditate { get; set; }
        public decimal EKG { get; set; }
        public System.DateTime DataMasurarii { get; set; }
        public string Status { get; set; }
        public System.Guid IDPacient { get; set; }
    
        public virtual Pacienti Pacienti { get; set; }
    }
}
