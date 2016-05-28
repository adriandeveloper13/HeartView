using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthView.Models;
using HeartView.Models;
using ActivitatePacienti = HealthView.Models.ActivitatePacienti;
using Doctori = HealthView.Models.Doctori;
using Pacienti = HealthView.Models.Pacienti;
using Recomandari = HealthView.Models.Recomandari;

namespace HealthView.BusinessLogic.TypeManagement
{
    public static class DasConfigurator
    {
        internal static void ConfigurePacienti(IMapperConfiguration config)
        {
            config.CreateMap<Pacienti, DataLayer.Pacienti>()
                .BeforeMap((source, destination) =>
                {
                    source.Doctori.Configure(doctor => { doctor.Pacienti = null; });
                    source.ActivitatePacienti.Configure(activitate => { activitate.Pacienti = null;  });
                    source.Recomandari.Configure(recomandare => { recomandare.Pacienti = null;  });
                });

            config.CreateMap<DataLayer.Pacienti, Pacienti>()
                .BeforeMap((source, destination) =>
                {
                    source.Doctori.Configure(doctor => { doctor.Pacienti = null; });
                    source.ActivitatePacienti.Configure(activitate => { activitate.Pacienti = null; });
                    source.Recomandari.Configure(recomandare => { recomandare.Pacienti = null; });
                });
        }

        internal static void ConfigureActivitatePacienti(IMapperConfiguration config)
        {
            config.CreateMap<ActivitatePacienti, DataLayer.ActivitatePacienti>()
                .BeforeMap((source, destination) =>
                {
                    source.Pacienti.Configure(pacient => { pacient.ActivitatePacienti = null; });
                    source.Doctori.Configure(doctor => { doctor.ActivitatePacienti = null; });
                });

            config.CreateMap<DataLayer.ActivitatePacienti, ActivitatePacienti>()
                .BeforeMap((source, destination) =>
                {
                    source.Pacienti.Configure(pacient => { pacient.ActivitatePacienti = null; });
                    source.Doctori.Configure(doctor => { doctor.ActivitatePacienti = null; });
                });
        }

        internal static void ConfigureDoctori(IMapperConfiguration config)
        {
            config.CreateMap<Doctori, DataLayer.Doctori>().BeforeMap((source, destination) =>
            {
                source.Pacienti.Configure(pacient => { pacient.Doctori = null; });
                source.ActivitatePacienti.Configure(activitate => { activitate.Doctori = null; });
                source.Recomandari.Configure(recomandare => { recomandare.Doctori = null; });
            });

            config.CreateMap<DataLayer.Doctori, Doctori>().BeforeMap((source, destination) =>
            {
                source.Pacienti.Configure(pacient => { pacient.Doctori = null; });
                source.ActivitatePacienti.Configure(activitate => { activitate.Doctori = null; });
                source.Recomandari.Configure(recomandare => { recomandare.Doctori = null; });
            });
        }

        internal static void ConfigureRecomandari(IMapperConfiguration config)
        {
            config.CreateMap<Recomandari, DataLayer.Recomandari>().BeforeMap((source, destination) =>
            {
                source.Pacienti.Configure(pacient => { pacient.Recomandari = null; });
                source.Doctori.Configure(doctor => { doctor.Recomandari = null; });
            });

            config.CreateMap<DataLayer.Doctori, Doctori>().BeforeMap((source, destination) =>
            {
                source.Pacienti.Configure(pacient => { pacient.Recomandari = null; });
            });
        }


        #region Item configuration extension methods

        private static void Configure<T>(this IEnumerable<T> items, Action<T> applyConfiguration)
        {
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                applyConfiguration(item);
            }
        }

        private static void Configure<T>(this T item, Action<T> applyConfiguration)
        {
            if (item == null)
            {
                return;
            }

            applyConfiguration(item);
        }

        #endregion
    }
}

