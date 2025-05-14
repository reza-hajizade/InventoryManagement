using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Domain.Repositories
{
    public interface IInventoryManagementRepository
    {
        Task AddAsync(Inventory inventory);

        Task<Inventory> GetByProductAsync(string product);

        Task<List<Inventory>> GetAllAsync();
        
    }
}
