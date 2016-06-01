using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthView.DataLayer.BaseRepo;

namespace HealthView.DataLayer.Repositories
{
    public class RecomandariRepository : BaseRepoWithSinglePk<Recomandari>
    {
        public RecomandariRepository(Entities context) : base(context)
        {
        }

        public override async Task<Recomandari> CreateAsync(Recomandari recomandare, IList<string> navigationProperties = null)
        {
            //foreach (var activitate in pacient.ActivitatePacienti)
            //{
            //    Context.Entry(activitate).State = EntityState.Unchanged;
            //}

            //foreach (var recomandare in pacient.Recomandari)
            //{
            //    Context.Entry(recomandare).State = EntityState.Unchanged;
            //}

            Context.Entry(recomandare.Doctori).State = EntityState.Unchanged;
            Context.Entry(recomandare.Pacienti).State = EntityState.Unchanged;

            return await base.CreateAsync(recomandare, navigationProperties);
        }

        public override async Task<Recomandari> UpdateAsync(Recomandari recomandare, IList<string> navigationProperties = null)
        {
            //foreach (var activitate in pacient.ActivitatePacienti)
            //{
            //    Context.Entry(activitate).State = EntityState.Unchanged;
            //}

            //foreach (var recomandare in pacient.Recomandari)
            //{
            //    Context.Entry(recomandare).State = EntityState.Unchanged;
            //}

            Context.Entry(recomandare.Doctori).State = EntityState.Unchanged;
            Context.Entry(recomandare.Pacienti).State = EntityState.Unchanged;

            return await base.UpdateAsync(recomandare, navigationProperties);
        }

        public async Task<IList<Recomandari>> ListAsync()
        {
            return await base.ListAllAsync().ConfigureAwait(false);
        }

        public async Task<IList<Recomandari>> GetAllByPacientIdAsync(Guid pacientId, IList<string> navigationProperties)
        {
            return await GetListAsync(recomandare => recomandare.IDPacient == pacientId, navigationProperties);
        }
    }
}
