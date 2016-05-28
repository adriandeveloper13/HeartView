using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HealthView.DataLayer.Interfaces;

namespace HealthView.DataLayer
{
    public class GenericDataRepository<T> : DataRepository
        where T : class, IDataAccesObject
    {
        private bool mIsEntityTrackingOn;
        private Func<IList<string>, IQueryable<T>> mQueryGenerator;
        protected DbSet<T> mDbSet;
        protected GenericDataRepository(Entities context) : base(context)
        {
            IsEntityTrackingOn = true;
        }
        public sealed override bool IsEntityTrackingOn
        {
            get { return mIsEntityTrackingOn; }
            set
            {
                mIsEntityTrackingOn = value;
                mQueryGenerator = mIsEntityTrackingOn ? (Func<IList<string>, IQueryable<T>>)GenerateQuery : GenerateNonTrackingQuery;
            }
        }
        public override Entities Context
        {
            get { return base.Context; }
            set
            {
                base.Context = value;
                mDbSet = value.Set<T>();
            }
        }
        protected virtual async Task<IList<T>> GetAllAsync(IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);
            var list = await dbQuery.ToListAsync();
            return list;
        }
        protected virtual async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);
            var list = await dbQuery.Where(@where).ToListAsync();
            return list;
        }
        protected virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);
            var item = await dbQuery.FirstOrDefaultAsync(@where);
            return item;
        }
        protected virtual async Task<T> AddAsync(T item)
        {
            mDbSet.Add(item);
            var result = await Context.SaveChangesAsync();
            return item;
        }
        protected virtual async Task<IList<T>> AddAsync(IList<T> items)
        {
            mDbSet.AddRange(items);
            var result = await Context.SaveChangesAsync();
            return items;
        }
        protected virtual async Task<T> ChangeAsync(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            var result = await Context.SaveChangesAsync();
            return item;
        }
        protected virtual async Task<IList<T>> ChangeAsync(IList<T> items)
        {
            Context.Configuration.AutoDetectChangesEnabled = false;
            foreach (var item in items)
            {
                Context.Entry(item).State = EntityState.Modified;
            }
            Context.Configuration.AutoDetectChangesEnabled = true;
            var result = await Context.SaveChangesAsync();
            return items;
        }
        protected virtual async Task DeleteAsync(T item)
        {
            mDbSet.Remove(item);
            var result = await Context.SaveChangesAsync();
        }
        protected virtual async Task DeleteAsync(IList<T> items)
        {
            mDbSet.RemoveRange(items);
            var result = await Context.SaveChangesAsync();
        }
        #region Private methods
        private IQueryable<T> GenerateNonTrackingQuery(IList<string> navigationProperties)
        {
            IQueryable<T> dbQuery = mDbSet.AsNoTracking();
            return ApplyNavigationProperties(dbQuery, navigationProperties);
        }
        private IQueryable<T> GenerateQuery(IList<string> navigationProperties)
        {
            IQueryable<T> dbQuery = mDbSet;
            return ApplyNavigationProperties(dbQuery, navigationProperties);
        }
        private static IQueryable<T> ApplyNavigationProperties(IQueryable<T> dbQuery, IList<string> navigationProperties)
        {
            if (navigationProperties != null)
            {
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));
            }
            return dbQuery;
        }
        #endregion
    }
}