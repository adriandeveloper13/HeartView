using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthView.DataLayer.Repositories;

namespace HealthView.DataLayer
{
    public class DataLayerUnitOfWork
    {
        private readonly IP_DatabaseEntities mContext;

        public DataLayerUnitOfWork()
        {
            mContext = new IP_DatabaseEntities();
        }

        #region Repository fields

        #endregion

        #region Repository properties

        #endregion

        //#region Repository factory

        private static IP_DatabaseEntities InstantiateContext()
        {
            return new IP_DatabaseEntities();
        }

        public static DoctoriRepository NewDoctoriRepository()
        {
            return new DoctoriRepository(InstantiateContext());
        }

        //public static WhiteLabelsRepository NewWhiteLabelsRepository()
        //{
        //    return new WhiteLabelsRepository(InstantiateContext());
        //}

        //public static CompaniesRepository NewCompaniesRepository()
        //{
        //    return new CompaniesRepository(InstantiateContext());
        //}

        //public static UsersRepository NewUsersRepository()
        //{
        //    return new UsersRepository(InstantiateContext());
        //}

        //public static GroupsRepository NewGroupsRepository()
        //{
        //    return new GroupsRepository(InstantiateContext());
        //}

        //public static TicketsRepository NewTicketsRepository()
        //{
        //    return new TicketsRepository(InstantiateContext());
        //}


        //public static VideosRepository NewVideosRepository()
        //{
        //    return new VideosRepository(InstantiateContext());
        //}

        //#endregion

        //#region Disposing logic

        public void Dispose()
        {
            mContext.Dispose();
        }
    }
}

