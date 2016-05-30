using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthView.BusinessLogic.BaseCore;
using HealthView.BusinessLogic.TypeManagement;
using HealthView.DataLayer;
using HealthView.DataLayer.BaseRepo;
using HealthView.DataLayer.Repositories;
using Pacienti = HealthView.Models.Pacienti;

namespace HealthView.BusinessLogic.ModelCore
{
    public class PacientiCore :BaseCoreWithSinglePk<Pacienti,DataLayer.Pacienti>
    {

        private static PacientiCore mInstance = null;

        public static PacientiCore Instance()
        {
            return mInstance ?? (mInstance = new PacientiCore());
        }

        internal override BaseRepo<DataLayer.Pacienti> GetRepoInstance(Entities context = null)
        {
            return new PacientiRepository(context ?? new Entities());
        }

        public async Task<IList<Pacienti>> List()
        {
            using (var pacientiRepository = (PacientiRepository)GetRepoInstance())
            {
                try
                {
                    var pacienti = await pacientiRepository.ListAsync();

                    if (pacienti == null || pacienti.Count == 0)
                    {
                        return new List<Pacienti>();
                    }

                    return pacienti.CopyTo<Pacienti>();
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }

        public async Task<IList<Pacienti>> GetAllByDoctorId(Guid doctorId, IList<string> navigationProperties = null)
        {
            using (var pacientiRepository = (PacientiRepository) GetRepoInstance())
            {
                var pacienti = await pacientiRepository.GetAllByDoctorIdAsync(doctorId, navigationProperties);

                return pacienti == null ? new List<Pacienti>() : pacienti.CopyTo<Pacienti>();
            }
        }
    }
}
