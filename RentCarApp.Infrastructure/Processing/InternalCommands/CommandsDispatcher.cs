using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RentCarApp.Application.Configuration.Processing;
using RentCarApp.Application.Customers;
using RentCarApp.Infrastructure.Database;

namespace RentCarApp.Infrastructure.Processing.InternalCommands
{
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly RentCarContext _ordersContext;

        public CommandsDispatcher(
            IMediator mediator, 
            RentCarContext ordersContext)
        {
            this._mediator = mediator;
            this._ordersContext = ordersContext;
        }

        public async Task DispatchCommandAsync(Guid id)
        {
            var internalCommand = await this._ordersContext.InternalCommands.SingleOrDefaultAsync(x => x.Id == id);

            Type type = Assembly.GetAssembly(typeof(MarkCustomerAsWelcomedCommand)).GetType(internalCommand.Type);
            dynamic command = JsonConvert.DeserializeObject(internalCommand.Data, type);

            internalCommand.ProcessedDate = DateTime.UtcNow;

            await this._mediator.Send(command);
        }
    }
}