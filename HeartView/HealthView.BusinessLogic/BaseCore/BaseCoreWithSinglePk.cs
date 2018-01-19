using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthView.BusinessLogic.BaseCore;
using HealthView.BusinessLogic.TypeManagement;
using HealthView.DataLayer.BaseRepo;
using HealthView.Models.Interfaces;
using LoggingService;
using HealthView.DataLayer.Interfaces;

namespace HealthView.BusinessLogic.BaseCore
{
    public abstract class BaseCoreWithSinglePk<T, U> : BaseCore<T, U>
                    where T : class, IModelWithSinglePK, new()
                    where U : class, IDataAccesObjectWithSinglePk, new()
    {
        public async Task<T> CreateAsync(T model, IList<string> navigationProperties = null)
        {
            using (var repoInstance = GetRepoInstance())
            {
                var dataLayerModel = model.CopyTo<U>();

                if (dataLayerModel.Id == Guid.Empty)
                {
                    dataLayerModel.Id = Guid.NewGuid();
                }

                dataLayerModel = await repoInstance.CreateAsync(dataLayerModel, navigationProperties);
                if (dataLayerModel == null)
                {
                    LogHelper.LogException("The entity could not be created");
                    return null;
                }
                return dataLayerModel.CopyTo<T>();
            }
        }

        public async Task<T> UpdateAsync(T model, IList<string> navigationProperties = null)
        {
            if (model.Id == Guid.Empty)
            {
                LogHelper.LogInfo("Attempted to update entity with empty Id");
                return null;
            }

            using (var repoInstance = GetRepoInstance())
            {
                var dataLayerModel = model.CopyTo<U>();
                if (model.Id == Guid.Empty)
                {
                    LogHelper.LogInfo("Attempted to update entity with empty Id");
                    return null;
                }
                try
                {
                    var updatedModel = await repoInstance.UpdateAsync(dataLayerModel, navigationProperties);
                    if (updatedModel == null)
                    {
                        LogHelper.LogException("The entity could not be updated");
                        return null;
                    }
                    return updatedModel.CopyTo<T>();
                }
            catch
            (Exception ex)
            {
                throw;
            }
        }
    }

        public async Task RemoveAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                LogHelper.LogInfo("Attempted to remove entity with empty Id");
                return;
            }
            using (var repoInstance = GetRepoInstance())
            {
                var singlePKRepo = CheckForBaseRepoWithSinglePkType(repoInstance);
                await singlePKRepo.RemoveAsync(id);
            }
        }
        public async Task<T> MarkAsync(Guid id, int status)
        {
            if (id == Guid.Empty)
            {
                LogHelper.LogInfo("Attempted to mark entity with empty Id");
                return null;
            }
            using (var repoInstance = GetRepoInstance())
            {
                var singlePKRepo = CheckForBaseRepoWithSinglePkType(repoInstance);
                var result = await singlePKRepo.MarkAsync(id, status);
                if (result == null)
                {
                    LogHelper.LogException("The entity could not be marked");
                    return null;
                }
                return result.CopyTo<T>();
            }
        }



        public async Task<T> GetAsync(Guid id, IList<string> navigationProperty = null)
        {
            using (var repoInstance = GetRepoInstance())
            {
                var singlePKRepo = CheckForBaseRepoWithSinglePkType(repoInstance);
                var entity = await singlePKRepo.GetAsync(id, navigationProperty);
                return entity.CopyTo<T>();
            }
        }

        #region private methods

        private static BaseRepoWithSinglePk<U> CheckForBaseRepoWithSinglePkType(BaseRepo<U> repoInstance)
        {
            var singlePKRepo = repoInstance as BaseRepoWithSinglePk<U>;
            if (singlePKRepo == null)
            {
                throw new Exception("repoInstance is not BaseRepoWithSinglePk");
            }
            return singlePKRepo;
        }

        #endregion
    }
}