using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dto
{
    public  record GetInventoryDto(string Product,int Stock);
   
}
