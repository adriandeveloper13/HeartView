using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthView.DataLayer.BaseRepo;

namespace HealthView.DataLayer.Repositories
{
    public class ActivitatePacientiRepository: BaseRepoWithSinglePk<ActivitatePacienti>
    {
        public ActivitatePacientiRepository(Entities context) : base(context)
        {
        }


        public async Task<IList<ActivitatePacienti>> ListAsync()
        {
            return await base.ListAllAsync().ConfigureAwait(false);
        }

        public async Task<ActivitatePacienti> GetByPacientIdAsync(Guid pacientId, IList<string> navigationProperties = null)
        {
            return await GetAsync(pacientId, navigationProperties);
        }

        public async Task<IList<ActivitatePacienti>> GetAllByDoctorIdAsync(Guid doctorId,
            IList<string> navigationProperties = null)
        {
            return await GetListAsync(activitatePacient => activitatePacient.IDDoctor == doctorId, navigationProperties);
        }
    }
}
