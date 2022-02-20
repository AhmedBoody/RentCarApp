using Autofac;
using RentCarApp.Application.Cities.DomainServices;
using RentCarApp.Domain.Cities;


namespace RentCarApp.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityUniquenessChecker>()
                .As<ICityUniquenessChecker>()
                .InstancePerLifetimeScope();

        }
    }
}