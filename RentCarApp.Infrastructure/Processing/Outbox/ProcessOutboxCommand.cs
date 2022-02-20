using MediatR;
using RentCarApp.Application;
using RentCarApp.Application.Configuration.Commands;

namespace RentCarApp.Infrastructure.Processing.Outbox
{
    public class ProcessOutboxCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}