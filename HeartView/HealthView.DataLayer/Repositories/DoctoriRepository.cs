using HealthView.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthView.Models;

namespace HealthView.DataLayer.Repositories
{
    public class DoctoriRepository: GenericDataRepository<Doctori>
    {
        internal DoctoriRepository(IP_DatabaseEntities context) : base(context) { }


        public async Task<IList<Doctori>> GetListAsync()
        {
            return await GetAllAsync();
        }
    }
}
