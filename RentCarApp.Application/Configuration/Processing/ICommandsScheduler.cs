using System.Threading.Tasks;
using MediatR;
using RentCarApp.Application.Configuration.Commands;

namespace RentCarApp.Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}