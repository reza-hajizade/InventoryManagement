using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EF.Models
{
    public class InventoryReadModel
    {
        public int Id { get; set; }
        public string Product { get;  set; }
        public int Stock { get;  set; }
    }
}
