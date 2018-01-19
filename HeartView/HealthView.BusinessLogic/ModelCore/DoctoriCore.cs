using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Helpers;
using DataLayer.StoreProcedures;
using HealthView.BusinessLogic.BaseCore;
using HealthView.BusinessLogic.TypeManagement;
using HealthView.DataLayer;
using HealthView.DataLayer.BaseRepo;
using HealthView.DataLayer.Repositories;
using HealthView.Interfaces;
using LoggingService;
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
                try
                {
                    var doctori = await doctoriRepository.ListAsync();

                    if (doctori == null || doctori.Count == 0)
                    {
                        return new List<Doctori>();
                    }

                    return doctori.CopyTo<Doctori>();
                }
                catch (Exception ex)
                {
                        
                    throw;
                }
                
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

        public async Task<IList<Doctori>> GetByAspNetUserId(Guid aspNetUserId)
        {
            using (var doctoriRepository = (DoctoriRepository) GetRepoInstance())
            {
                var doctori = await doctoriRepository.GetAllByAspNetUserIdAsync(aspNetUserId);
                if (doctori == null || doctori.Count == 0)
                {
                    return new List<Doctori>();
                }

                return doctori.CopyTo<Doctori>();
            }
        }

        //public async Task<IList<Doctori>> GetByEmail(string email)
        //{
        //    using (var doctoriRepository = (DoctoriRepository)GetRepoInstance())
        //    {
        //        var doctori = await doctoriRepository.GetByEmail(email);
        //        //if (doctori == null || doctori.Count == 0)
        //        //{
        //        //    return new List<Doctori>();
        //        //}

        //        return doctori.CopyTo<Doctori>();
        //    }
        //}

        //public List<T> GetUserIdentityData<T>(string aspNetUserId) where T : class, IUserIdentityData, new()
        //{
        //    var spExec = new StoredProcedureExecutor();
        //    StoredProcedureBase getUserIdentityData = new User_Get_Identity_Data_SP(aspNetUserId);
        //    OperationStatus status = null;
        //    var userIdentityData = spExec.GetMultipleSetResult<T>(getUserIdentityData, out status);
        //    if (status != null && !status.Error)
        //    {
        //        return userIdentityData;
        //    }
        //    if (status != null)
        //    {
        //        LogHelper.LogInfo<UserCore>($"failed at GetUserIdentityData with errorCode {status.ErrorCode}");
        //    }
        //    return userIdentityData;
        //}
    }
}
