using Microsoft.EntityFrameworkCore;
using RentCarApp.Domain.Cities;
using RentCarApp.Domain.Features;
using RentCarApp.Domain.Manufacturers;
using RentCarApp.Infrastructure.Processing.InternalCommands;
using RentCarApp.Infrastructure.Processing.Outbox;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RentCarApp.Infrastructure.Database
{
    public class RentCarContext : DbContext
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Manufacturer> Manufactures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }

        public RentCarContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentCarContext).Assembly);
        }
    }

    public static class QueryableExtension
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
        internal static IQueryable<T> IncludeMultiLevel<T>(this IQueryable<T> query,
         string[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }
}
