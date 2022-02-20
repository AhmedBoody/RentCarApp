using MediatR;
using Newtonsoft.Json;
using RentCarApp.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Application.Customers
{
   
    public class MarkCustomerAsWelcomedCommand : InternalCommandBase<Unit>
    {
        [JsonConstructor]
        public MarkCustomerAsWelcomedCommand(Guid id, Guid customerId) : base(id)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}
