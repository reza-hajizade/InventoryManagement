using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Shared.Abstractions.Exceptions;

namespace InventoryManagement.Application.Exceptions
{
    public class InventoryNotFoundException:InventoryManagementException
    {
        public InventoryNotFoundException():base("This Inventory Not Found")
        {
            
        }
    }
}
