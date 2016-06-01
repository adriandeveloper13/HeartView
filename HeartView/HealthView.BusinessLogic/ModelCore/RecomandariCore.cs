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
using Recomandari = HealthView.Models.Recomandari;

namespace HealthView.BusinessLogic.ModelCore
{
    public class RecomandariCore : BaseCoreWithSinglePk<Recomandari, DataLayer.Recomandari>
    {

        private static RecomandariCore mInstance = null;

        public static RecomandariCore Instance()
        {
            return mInstance ?? (mInstance = new RecomandariCore());
        }

        internal override BaseRepo<DataLayer.Recomandari> GetRepoInstance(Entities context = null)
        {
            return new RecomandariRepository(context ?? new Entities());
        }

        public async Task<IList<Recomandari>> List()
        {
            using (var recomandariRepository = (RecomandariRepository)GetRepoInstance())
            {
                try
                {
                    var recomandari = await recomandariRepository.ListAsync().ConfigureAwait(false);

                    if (recomandari == null && recomandari.Count == 0)
                    {
                        return new List<Recomandari>();
                    }

                    return recomandari.CopyTo<Recomandari>();
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }

        public async Task<IList<Recomandari>> GetAllByPacientId(Guid pacientId,
            IList<string> navigationProperties = null)
        {
            using (var recomandariRepository = (RecomandariRepository) GetRepoInstance())
            {
                var recomandari = await recomandariRepository.GetAllByPacientIdAsync(pacientId, navigationProperties);

                if (recomandari == null && recomandari.Count == 0)
                {
                    return new List<Recomandari>();
                }

                return recomandari.CopyTo<Recomandari>();
            }
        }
    }
}
