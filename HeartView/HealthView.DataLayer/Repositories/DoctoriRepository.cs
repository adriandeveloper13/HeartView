using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using CBT.DataLayer;
using CBT.DataLayer.BaseRepo;
using HealthView.DataLayer.BaseRepo;

namespace HealthView.DataLayer.Repositories
{
    public class DoctoriRepository: BaseRepoWithSinglePk<Doctori>
    {
        public DoctoriRepository(Entities context) : base(context)
        {
        }

        public override async Task<Doctori> CreateAsync(Doctori doctor, IList<string> navigationProperties = null)
        {
            //TODO: Check this
            foreach (var pacient in doctor.Pacienti)
            {
                Context.Entry(pacient).State = EntityState.Unchanged;
            }

            return await base.CreateAsync(doctor, navigationProperties);
        }

        public override async Task<Doctori> UpdateAsync(Doctori doctor, IList<string> navigationProperties = null)
        {
            //TODO: check this
            foreach (var pacient in doctor.Pacienti)
            {
                Context.Entry(pacient).State = EntityState.Unchanged;
            }

            return await base.UpdateAsync(doctor, navigationProperties);
        }

        public async Task<IList<Doctori>> GetAllByGroupIdAsync(Guid pacientId, IList<string> navigationProperties = null)
        {
            return await GetListAsync(user => user.Pacienti.Any(pacienti => pacienti.Id == pacientId), navigationProperties);
        }

        public async Task<IList<Doctori>> ListAsync()
        {
            return await base.GetAllAsync();
        }

        public async Task<IList<Doctori>> GetAllByAspNetUserIdAsync(Guid aspNetUserId, IList<string> navigationProperties = null)
        {
            return await GetListAsync(doctor => doctor.AspNetUserId == aspNetUserId.ToString(), navigationProperties);
        }
    }
}
