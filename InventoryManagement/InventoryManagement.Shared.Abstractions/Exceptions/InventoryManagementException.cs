using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Shared.Abstractions.Exceptions
{
    public abstract class InventoryManagementException:Exception
    {
        protected InventoryManagementException(string message):base(message)
        {
            
        }
    }
}
