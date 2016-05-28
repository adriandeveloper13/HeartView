﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthView.BusinessLogic.TypeManagement;
using HealthView.DataLayer.Interfaces;
using HealthView.Models.Interfaces;

namespace HealthView.BusinessLogic
{
    internal static class DataAdapterService
    {
        private static IMapper mMapper;

        static DataAdapterService()
        {
            InitializeMapper();
        }

        private static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                DasConfigurator.ConfigureDoctori(config);
                DasConfigurator.ConfigurePacienti(config);
                DasConfigurator.ConfigureActivitatePacienti(config);
                DasConfigurator.ConfigureIdentitate(config);
                DasConfigurator.ConfigureRecomandari(config);

            });
            mapperConfiguration.AssertConfigurationIsValid();
            mMapper = mapperConfiguration.CreateMapper();
        }

        #region IModel

        /// <summary>
        ///     Copies the object to a new entity of type <typeparamref name="TDestType" /> by mapping their properties one-to-one
        /// </summary>
        /// <typeparam name="TDestType">The type of returned entity</typeparam>
        /// <param name="entity">The entity that will be copied to the new type</param>
        /// <returns>An entity of type <typeparamref name="TDestType" /> that contains all the properties from the source object</returns>
        public static TDestType CopyTo<TDestType>(this IModel entity)
            where TDestType : class
        {
            return entity != null ? mMapper.Map<TDestType>(entity) : null;
        }

        /// <summary>
        ///     Copies the list of objects to a new list with entities of type <typeparamref name="TDestType" /> by mapping their
        ///     properties one-to-one,
        ///     in the same order as found in the source list
        /// </summary>
        /// <typeparam name="TDestType">The type of the entities in the returned list</typeparam>
        /// <param name="entityList">The list of entities that will be copied to the new type</param>
        /// <returns>
        ///     A list with entities of type <typeparamref name="TDestType" /> that contain all the properties from the source
        ///     objects
        /// </returns>
        public static IList<TDestType> CopyTo<TDestType>(this IEnumerable<IModel> entityList)
            where TDestType : class
        {
            return entityList != null ? mMapper.Map<IList<TDestType>>(entityList) : null;
        }

        #endregion

        #region IDataAccessObject

        /// <summary>
        ///     Copies the object to a new entity of type <typeparamref name="TDestType" /> by mapping their properties one-to-one
        /// </summary>
        /// <typeparam name="TDestType">The type of returned entity</typeparam>
        /// <param name="entity">The entity that will be copied to the new type</param>
        /// <returns>An entity of type <typeparamref name="TDestType" /> that contains all the properties from the source object</returns>
        public static TDestType CopyTo<TDestType>(this IDataAccesObject entity)
            where TDestType : class
        {
            return entity != null ? mMapper.Map<TDestType>(entity) : null;
        }


        /// <summary>
        ///     Copies the list of objects to a new list with entities of type <typeparamref name="TDestType" /> by mapping their
        ///     properties one-to-one,
        ///     in the same order as found in the source list
        /// </summary>
        /// <typeparam name="TDestType">The type of the entities in the returned list</typeparam>
        /// <param name="entityList">The list of entities that will be copied to the new type</param>
        /// <returns>
        ///     A list with entities of type <typeparamref name="TDestType" /> that contain all the properties from the source
        ///     objects
        /// </returns>
        public static IList<TDestType> CopyTo<TDestType>(this IEnumerable<IDataAccesObject> entityList)
            where TDestType : class
        {
            return entityList != null ? mMapper.Map<IList<TDestType>>(entityList) : null;
        }

        #endregion
    }
}