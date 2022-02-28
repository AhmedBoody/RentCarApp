using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCarApp.Application;
using RentCarApp.Application.Configuration.Data;
using RentCarApp.Domain.Cities;
using RentCarApp.Domain.SeedWork;
using RentCarApp.Infrastructure.Domain;
using RentCarApp.Infrastructure.Domain.Cities;
using RentCarApp.Infrastructure.SeedWork;

namespace RentCarApp.Infrastructure.Database
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            

            builder.RegisterType<StronglyTypedIdValueConverterSelector>()
                .As<IValueConverterSelector>()
                .SingleInstance();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<RentCarContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new RentCarContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}