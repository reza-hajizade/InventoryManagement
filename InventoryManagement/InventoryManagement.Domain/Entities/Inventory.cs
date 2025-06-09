using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Inventory
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Product { get;private set; }
        public int Stock { get;private set; }


        public static Inventory Create(string product,int stock)
        {
            return new Inventory
            {
                
                Product = product,
                Stock = stock
            };
        }

        public void Decreasestock(int quantity)
        {
            Stock -= quantity;
        }

    }

    
}
