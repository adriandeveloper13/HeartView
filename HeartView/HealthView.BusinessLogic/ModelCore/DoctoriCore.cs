using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthView.BusinessLogic.BaseCore;
using HealthView.DataLayer;
using HealthView.DataLayer.BaseRepo;
using HealthView.DataLayer.Repositories;
using Doctori = HealthView.Models.Doctori;

namespace HealthView.BusinessLogic.ModelCore
{
    public class DoctoriCore : BaseCoreWithSinglePk<Doctori, DataLayer.Doctori>
    {
        private static DoctoriCore mInstance = null;

        public static DoctoriCore Instance()
        {
            return mInstance ?? (mInstance = new DoctoriCore());
        }

        internal override BaseRepo<DataLayer.Doctori> GetRepoInstance(Entities context = null)
        {
            return new DoctoriRepository(context ?? new Entities());
        }

        public async Task<IList<Doctori>> List()
        {
            using (var doctoriRepository = (DoctoriRepository) GetRepoInstance())
            {
                var doctori = await doctoriRepository.ListAsync();

                if (doctori == null || doctori.Count == 0)
                {
                    return new List<Doctori>();
                }

                return doctori.CopyTo<Doctori>();
            }
        }



        //public async Task<IList<Doctori>> GetAllByCompanyIdAsync(Guid companyId, IList<string> navigationProperties = null)
        //{
        //    using (var doctoriRepository = (DoctoriRepository)GetRepoInstance())
        //    {
        //        var doctori = await doctoriRepository.GetAllByCompanyIdAsync(companyId, navigationProperties);

        //        if (doctori == null || doctori.Count == 0)
        //        {
        //            return new List<Doctori>();
        //        }

        //        return doctori.CopyTo<Doctori>();
        //    }
        //}

    }
}
