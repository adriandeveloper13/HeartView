using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthView.BusinessLogic.BaseCore;
using HealthView.DataLayer;
using HealthView.DataLayer.BaseRepo;
using HealthView.DataLayer.Repositories;
using Doctori = HeartView.Models.Doctori;

namespace HealthView.BusinessLogic.ModelCore
{
    public class DoctoriCore : BaseCoreWithSinglePk<Doctori, DataLayer.Doctori>
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
