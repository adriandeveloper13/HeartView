using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HealthView.DataLayer.BaseRepo;

namespace HealthView.DataLayer.Repositories
{
    public class PacientiRepository : BaseRepoWithSinglePk<Pacienti>
    {
        public PacientiRepository(Entities context) : base(context)
        {
        }

        public override async Task<Pacienti> CreateAsync(Pacienti pacient, IList<string> navigationProperties = null)
        {
            foreach (var activitate in pacient.ActivitatePacienti)
            {
                Context.Entry(activitate).State = EntityState.Unchanged;
            }

            foreach (var recomandare in pacient.Recomandari)
            {
                Context.Entry(recomandare).State = EntityState.Unchanged;
            }

            //Context.Entry(pacient.AspNetUsers).State = EntityState.Unchanged;
            //Context.Entry(pacient.Doctori).State = EntityState.Unchanged;

            return await base.CreateAsync(pacient, navigationProperties);
        }

        public override async Task<Pacienti> UpdateAsync(Pacienti pacient, IList<string> navigationProperties = null)
        {
            foreach (var activitate in pacient.ActivitatePacienti)
            {
                Context.Entry(activitate).State = EntityState.Unchanged;
            }

            foreach (var recomandare in pacient.Recomandari)
            {
                Context.Entry(recomandare).State = EntityState.Unchanged;
            }

            //Context.Entry(pacient.AspNetUsers).State = EntityState.Unchanged;
            //Context.Entry(pacient.Doctori).State = EntityState.Unchanged;

            return await base.UpdateAsync(pacient, navigationProperties);
        }

        public async Task<IList<Pacienti>> ListAsync()
        {
            return await base.ListAllAsync().ConfigureAwait(false);
        }

        public async Task<IList<Pacienti>> GetAllByDoctorIdAsync(Guid doctorId, IList<string> navigationProperties)
        {
            return await GetListAsync(pacient => pacient.IDDoctor == doctorId, navigationProperties);
        }
    }
}
