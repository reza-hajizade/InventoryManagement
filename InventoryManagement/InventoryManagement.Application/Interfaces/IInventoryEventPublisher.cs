using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Shared.Contracts.Events;

namespace InventoryManagement.Application.Interfaces
{
    public interface IInventoryEventPublisher
    {
        Task PublishInventoryReservedEventAsync(InventoryReservedEvent @event);
        Task PublishInventoryFailedEventAsync(InventoryFailedEvent @event);
    }
}
