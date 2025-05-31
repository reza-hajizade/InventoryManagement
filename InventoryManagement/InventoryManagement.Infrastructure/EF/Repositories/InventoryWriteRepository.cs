using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repositories;
using InventoryManagement.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EF.Repositories
{
    public class InventoryWriteRepository : IInventoryWriteRepository
    {
        private readonly WriteDbContext _writeDbContext;
        public InventoryWriteRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task AddAsync(Inventory inventory)
        {
           await _writeDbContext.Inventories.AddAsync(inventory);
        }

        public async Task<Inventory> GetByProductAsync(string product)
        {
            var result = await _writeDbContext.Inventories.FirstOrDefaultAsync(p => p.Product == product);
            return result;
        }
    }
}
