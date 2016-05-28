using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthView.Interfaces
{
    public  interface IUserIdentityData
    {
        string IDPacient { get; set; }
        string IDActivitate { get; set; }
        string IDDoctor { get; set; }
        string IDRecomandare { get; set; }

        string NumePacient { get; set; }
        string PrenumePacient { get; set; }

        string CNPpacient { get; set; }
        string Varsta { get; set; }
        string Adresa { get; set; }
        string Telefon { get; set; }
        string Email { get; set; }
        string Status { get; set; }
        string Ocupatie { get; set; }

        string NumeDoctor { get; set; }
        string PrenumeDoctor { get; set; }
        string Spital { get; set; }
        string Functie { get; set; }
    }
}
