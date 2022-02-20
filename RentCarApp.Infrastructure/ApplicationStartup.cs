using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using RentCarApp.Application.Configuration;
using RentCarApp.Application.Configuration.Emails;
using RentCarApp.Infrastructure.Caching;
using RentCarApp.Infrastructure.Database;
using RentCarApp.Infrastructure.Domain;
using RentCarApp.Infrastructure.Emails;
using RentCarApp.Infrastructure.Logging;
using RentCarApp.Infrastructure.Processing;
using RentCarApp.Infrastructure.Processing.InternalCommands;
using RentCarApp.Infrastructure.Processing.Outbox;
using RentCarApp.Infrastructure.Quartz;
using RentCarApp.Infrastructure.SeedWork;
using Serilog;

namespace RentCarApp.Infrastructure
{
    public class ApplicationStartup
    {
        public static IServiceProvider Initialize(
            IServiceCollection services,
            string connectionString,
            ICacheStore cacheStore,
            IEmailSender emailSender,
            EmailsSettings emailsSettings,
            ILogger logger,
            IExecutionContextAccessor executionContextAccessor,
            bool runQuartz = true)
        {
            if (runQuartz)
            {
                StartQuartz(connectionString, emailsSettings, logger, executionContextAccessor);
            }

            services.AddSingleton(cacheStore);

            var serviceProvider = CreateAutofacServiceProvider(
                services, 
                connectionString, 
                emailSender, 
                emailsSettings,
                logger,
                executionContextAccessor);

            return serviceProvider;
        }

        private static IServiceProvider CreateAutofacServiceProvider(
            IServiceCollection services,
            string connectionString,
            IEmailSender emailSender,
            EmailsSettings emailsSettings,
            ILogger logger,
            IExecutionContextAccessor executionContextAccessor)
        {
            var container = new ContainerBuilder();

            container.Populate(services);

            container.RegisterModule(new LoggingModule(logger));
            container.RegisterModule(new DataAccessModule(connectionString));
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new DomainModule());
            
            if (emailSender != null)
            {
                container.RegisterModule(new EmailModule(emailSender, emailsSettings));
            }
            else
            {
                container.RegisterModule(new EmailModule(emailsSettings));
            }
            
            container.RegisterModule(new ProcessingModule());

            container.RegisterInstance(executionContextAccessor);

            var buildContainer = container.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(buildContainer));

            var serviceProvider = new AutofacServiceProvider(buildContainer);

            CompositionRoot.SetContainer(buildContainer);

            return serviceProvider;
        }

        private static void StartQuartz(
            string connectionString, 
            EmailsSettings emailsSettings,
            ILogger logger,
            IExecutionContextAccessor executionContextAccessor)
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            var container = new ContainerBuilder();

            container.RegisterModule(new LoggingModule(logger));
            container.RegisterModule(new QuartzModule());
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new DataAccessModule(connectionString));
            container.RegisterModule(new EmailModule(emailsSettings));
            container.RegisterModule(new ProcessingModule());

            container.RegisterInstance(executionContextAccessor);
            container.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<RentCarContext>();
                dbContextOptionsBuilder.UseSqlServer(connectionString);

                dbContextOptionsBuilder
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                return new RentCarContext(dbContextOptionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();

            scheduler.JobFactory = new JobFactory(container.Build());

            scheduler.Start().GetAwaiter().GetResult();

            var processOutboxJob = JobBuilder.Create<ProcessOutboxJob>().Build();
            var trigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/15 * * ? * *")
                    .Build();

            scheduler.ScheduleJob(processOutboxJob, trigger).GetAwaiter().GetResult();

            var processInternalCommandsJob = JobBuilder.Create<ProcessInternalCommandsJob>().Build();
            var triggerCommandsProcessing =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/15 * * ? * *")
                    .Build();
            scheduler.ScheduleJob(processInternalCommandsJob, triggerCommandsProcessing).GetAwaiter().GetResult();
        }
    }
}