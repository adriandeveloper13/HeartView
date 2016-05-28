using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBT.DataLayer.Interfaces;
using LoggingService;

namespace CBT.DataLayer.BaseRepo
{
    public class BaseRepoWithSinglePk<T> : BaseRepo<T>
    where T : class, IDataAccesObjectWithSinglePk, new()
    {
        public BaseRepoWithSinglePk(Entities context) : base(context)
        {
        }

        public override async Task<T> CreateAsync(T model, IList<string> navigationProperties = null)
        {
            await AddAsync(model);
            return await GetAsync(model.Id, navigationProperties);
        }

        public override async Task<T> UpdateAsync(T model, IList<string> navigationProperties = null)
        {
            await ChangeAsync(model);
            return await GetAsync(model.Id, navigationProperties);
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await mDbSet.FindAsync(id);
            if (entity == null)
            {
                LogHelper.LogInfo("Attempted to remove entity which does not exist in the database");
                return;
            }
            await DeleteAsync(entity);
        }

        public async Task<T> MarkAsync(Guid id, int status)
        {
            var entity = await mDbSet.FindAsync(id);
            if (entity == null)
            {
                LogHelper.LogInfo("Attempted to mark entity which does not exist in the database");
                return null;
            }
            var entityWithStatus = (IDataAccesObjectWithStatus) entity;
            if (entityWithStatus == null)
            {
                throw new Exception("entityWithStatus is not IDataAccesObjectWithStatus");
            }

            entityWithStatus.Status = status;
            await UpdateAsync(entity);

            return await mDbSet.FindAsync(id);
        }

        public async Task<T> GetAsync(Guid id, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(entity => entity.Id == id, navigationProperties);
        }

        //public async Task<IList<T>> GetAllAsync(int status, IList<string> navigationProperties = null)
        //{
        //    return await GetListAsync(entity => entity.Status == status, navigationProperties);
        //}
    }
}