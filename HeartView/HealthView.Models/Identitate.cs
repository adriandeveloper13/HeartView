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
    
    public partial class Identitate : Interfaces.IModel
    {
        public System.Guid IDUser { get; set; }
        public string Utilizator { get; set; }
        public string Parola { get; set; }
        public System.Guid Rol { get; set; }
    
        public virtual Doctori Doctori { get; set; }
        public virtual Pacienti Pacienti { get; set; }
    }
}
