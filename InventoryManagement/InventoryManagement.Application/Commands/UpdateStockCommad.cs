using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InventoryManagement.Application.Commands
{
    public sealed record UpdateStockCommad(int Id,string Product,int Quantity):IRequest;
   
}
