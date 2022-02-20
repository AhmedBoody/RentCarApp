using MediatR;
using RentCarApp.Application;
using RentCarApp.Application.Configuration.Commands;
using RentCarApp.Infrastructure.Processing.Outbox;

namespace RentCarApp.Infrastructure.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}