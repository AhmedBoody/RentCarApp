using System.Threading;
using System.Threading.Tasks;
using RentCarApp.Domain.SeedWork;
using RentCarApp.Infrastructure.Database;
using RentCarApp.Infrastructure.Processing;

namespace RentCarApp.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentCarContext _ordersContext;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public UnitOfWork(
            RentCarContext ordersContext, 
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            this._ordersContext = ordersContext;
            this._domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this._domainEventsDispatcher.DispatchEventsAsync();
            return await this._ordersContext.SaveChangesAsync(cancellationToken);
        }
    }
}