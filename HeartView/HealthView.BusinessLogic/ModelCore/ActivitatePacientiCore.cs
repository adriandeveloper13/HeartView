using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using HealthView.BusinessLogic.BaseCore;
using HealthView.BusinessLogic.TypeManagement;
using HealthView.DataLayer;
using HealthView.DataLayer.BaseRepo;
using HealthView.DataLayer.Repositories;
using LoggingService;
using ActivitatePacienti = HealthView.Models.ActivitatePacienti;

namespace HealthView.BusinessLogic.ModelCore
{
    public class ActivitatePacientiCore: BaseCoreWithSinglePk<ActivitatePacienti, DataLayer.ActivitatePacienti>
    {
        private static ActivitatePacientiCore mInstance = null;

        public static ActivitatePacientiCore Instance()
        {
            return mInstance ?? (mInstance = new ActivitatePacientiCore());
        }

        internal override BaseRepo<DataLayer.ActivitatePacienti> GetRepoInstance(Entities context = null)
        {
            return new ActivitatePacientiRepository(context ?? new Entities() );
        }


        public async Task<IList<ActivitatePacienti>> List()
        {
            using (var activitatePacientiRepository = (ActivitatePacientiRepository)GetRepoInstance())
            {
                try
                {
                    var activitatePacienti = await activitatePacientiRepository.ListAsync().ConfigureAwait(false);

                    if (activitatePacienti == null || activitatePacienti.Count == 0)
                    {
                        return new List<ActivitatePacienti>();
                    }

                    return activitatePacienti.CopyTo<ActivitatePacienti>();
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }
        
        
    }
}
