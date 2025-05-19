using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Shared.Contracts.Events;
using MassTransit;
using MediatR;

namespace InventoryManagement.Infrastructure.Messaging.Publishers
{
    public class InventoryEventPublisher : IInventoryEventPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public InventoryEventPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
      

        public  async Task PublishInventoryFailedEventAsync(InventoryFailedEvent @event)
        {
            await _publishEndpoint.Publish(@event);
        }

        public  async Task PublishInventoryReservedEventAsync(InventoryReservedEvent @event)
        {
           await  _publishEndpoint.Publish(@event);
        }

    }
}
