using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Repositories
{
    public interface IInventoryWriteRepository
    {
        Task AddAsync(Inventory inventory);

        Task<Inventory> GetByProductAsync(string product);
    }
}
