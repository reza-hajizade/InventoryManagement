using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Commands;
using InventoryManagement.Infrastructure.EF.Context;
using InventoryManagement.Shared.Contracts.Events;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Shared.Contracts.Events;


namespace InventoryManagement.Infrastructure.Messaging.Consumer
{
    public class OrderCreatedEventConsumer(WriteDbContext writeDbContext,
        IMediator mediator) : IConsumer<OrderCreatedEvent>
    {
        private readonly WriteDbContext  _writeDbContext = writeDbContext;
        private readonly IMediator _mediator=mediator;
       
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var inventory = await _writeDbContext.Inventories.FirstOrDefaultAsync(p => p.Product == context.Message.Name);

            if (inventory is null)
            {
                Console.WriteLine("inventory not found");
                return;
            }

           await _mediator.Send(new UpdateStockCommad(context.Message.Id,inventory.Product,context.Message.Quantity));
          
        }
    }
}
