using System;
using System.Threading.Tasks;

namespace RentCarApp.Infrastructure.Processing
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
