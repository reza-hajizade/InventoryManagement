using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Shared.Contracts.Events
{

    public record InventoryFailedEvent(Guid Id,string Name, DateTime OccuredOn);
}
