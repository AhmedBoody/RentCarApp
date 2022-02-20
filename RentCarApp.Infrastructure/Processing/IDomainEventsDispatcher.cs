using System.Threading.Tasks;

namespace RentCarApp.Infrastructure.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}