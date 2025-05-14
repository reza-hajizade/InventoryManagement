using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.Repositories;
using MediatR;

namespace InventoryManagement.Application.Commands
{
    public sealed record CreateInventoryCommand(string Product,int Stock):IRequest;
  
}
