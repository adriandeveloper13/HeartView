using System.Collections.Generic;
using System.Threading.Tasks;
using HealthView.DataLayer.Interfaces;

namespace HealthView.DataLayer.BaseRepo
{
    public abstract class BaseRepo<T> : GenericDataRepository<T>
    where T : class, IDataAccesObject
    {
        public BaseRepo(IP_DatabaseEntities context) : base(context)
        {
        }

        public abstract Task<T> CreateAsync(T model, IList<string> navigationProperties = null);


        public abstract Task<T> UpdateAsync(T model, IList<string> navigationProperties = null);
    }
}