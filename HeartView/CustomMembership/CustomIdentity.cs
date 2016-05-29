using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CustomMembership
{
    public class CustomIdentity : IIdentity
    {
        #region from interface

        public string Name => IsAuthenticated ? UserName : null;

        public string AuthenticationType => "Custom";

        public bool IsAuthenticated => Id != Guid.Empty;

        #endregion


        #region custom fields

        public Guid Id { get; set; }
        public string AspNetUserId { get; set; }
        public Guid IDPacient { get; set; }
        public Guid IDActivitate { get; set; }
        public Guid IDRecomandare { get; set; }

        public string NumePacient { get; set; }
        public string PrenumePacient { get; set; }
        public string UserName { get; set; }
        public string CNPpacient { get; set; }
        public string Varsta { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Ocupatie { get; set; }

        public string NumeDoctor { get; set; }
        public string PrenumeDoctor { get; set; }
        public string Spital { get; set; }
        public string Functie { get; set; }
        #endregion
    }
}
