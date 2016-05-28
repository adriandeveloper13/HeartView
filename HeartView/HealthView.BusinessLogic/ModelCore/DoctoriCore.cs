using System.Collections.Generic;
using System.Threading.Tasks;
using CBT.DataLayer.BaseRepo;
using HealthView.DataLayer;
using HealthView.DataLayer.Repositories;
using Doctori = HeartView.Models.Doctori;

namespace HealthView.BusinessLogic.ModelCore
{
    public class DoctoriCore
    {
        private static DoctoriCore mInstance = null;
        public static DoctoriCore Instance()
        {
            return mInstance ?? (mInstance = new DoctoriCore());
        }

        internal override BaseRepo<DataLayer.Doctori> GetRepoInstance(IP_DatabaseEntities context = null)
        {
            return new DoctoriRepository(context ?? new IP_DatabaseEntities());
        }


        public async Task <IList<Doctori>>GetListAsync(IList<string> navigationProperties = null)
        {
            using (var companyRepository = (DoctoriRepository)GetRepoInstance())
            {
                var doctori = await companyRepository.GetListAsync(navigationProperties);
                if (doctori == null)
                {
                    return new List<Doctori>();
                }
                return doctori.CopyTo<Doctori>();
            }
        }
    }
    }
}
