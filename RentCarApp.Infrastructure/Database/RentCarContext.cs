using Microsoft.EntityFrameworkCore;
using RentCarApp.Domain.Cities;

using RentCarApp.Infrastructure.Processing.InternalCommands;
using RentCarApp.Infrastructure.Processing.Outbox;

namespace RentCarApp.Infrastructure.Database
{
    public class RentCarContext : DbContext
    {

        public DbSet<City> Cities { get; set; }
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
}
