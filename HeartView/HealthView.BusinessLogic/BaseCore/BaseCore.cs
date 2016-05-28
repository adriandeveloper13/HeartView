using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthView.DataLayer;
using HealthView.DataLayer.BaseRepo;
using HealthView.DataLayer.Interfaces;
using HealthView.Models.Interfaces;

namespace HealthView.BusinessLogic.BaseCore
{
    public abstract class BaseCore<T, U>
        where T : class, IModel, new()
        where U : class, IDataAccesObject, new()
    {
        internal abstract BaseRepo<U> GetRepoInstance(IP_DatabaseEntities context = null);
    }
}
