using System;
using HealthView.DataLayer;

namespace HealthView.DataLayer
{
    public abstract class DataRepository : IDisposable
    {
        private IP_DatabaseEntities mContext;

        protected internal DataRepository(IP_DatabaseEntities context)
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Context = context;
        }

        public virtual IP_DatabaseEntities Context
        {
            get
            {
                return mContext;
            }
            set
            {
                if (value != null)
                {
                    mContext = value;
                }
                else
                {
                    //TODO 
                    //LogHelper.LogException<DataRepository>("Could not create the database context.");
                    throw new NullReferenceException("Tried to use repository with null context");
                }
            }
        }

        public abstract bool IsEntityTrackingOn { get; set; }

        #region Disposing logic

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion
    }
}