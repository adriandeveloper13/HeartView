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
    
    public partial class Recomandari:Interfaces.IModel
    {
        public System.Guid IDRecomandare { get; set; }
        public System.Guid IDPacient { get; set; }
        public string TipRecomandare { get; set; }
        public decimal Durata { get; set; }
        public string AlteIndicatii { get; set; }
    
        public virtual Pacienti Pacienti { get; set; }
    }
}
