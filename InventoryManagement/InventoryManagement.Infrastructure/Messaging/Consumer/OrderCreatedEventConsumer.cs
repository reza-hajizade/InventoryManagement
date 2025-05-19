using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Commands;
using InventoryManagement.Shared.Contracts.Events;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Shared.Contracts.Events;


namespace InventoryManagement.Infrastructure.Messaging.Consumer
{
    public class OrderCreatedEventConsumer(InventoryManagementDbContext inventoryManagementDbContext,
        IMediator mediator) : IConsumer<OrderCreatedEvent>
    {
        private readonly InventoryManagementDbContext _inventoryManagementDbContext = inventoryManagementDbContext;
        private readonly IMediator _mediator=mediator;
       
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var inventory = await _inventoryManagementDbContext.Inventories.FirstOrDefaultAsync(p => p.Product == context.Message.Name);

            if (inventory is null)
            {
                Console.WriteLine("inventory not found");
                return;
            }

           await _mediator.Send(new UpdateStockCommad(context.Message.Id,inventory.Product,context.Message.Quantity));
          


        }



    }
}
