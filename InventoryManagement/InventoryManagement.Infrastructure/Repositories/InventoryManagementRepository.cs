using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Repositories
{
    internal class InventoryManagementRepository : IInventoryManagementRepository
    {
        private readonly InventoryManagementDbContext _context;
        public InventoryManagementRepository(InventoryManagementDbContext context)
        {
            _context = context; 
        }

        public async Task AddAsync(Inventory inventory)
        {
            await _context.Inventories.AddAsync(inventory); 
         }

        public async Task<List<Inventory>> GetAllAsync()
        {
            var invertory = await _context.Inventories.ToListAsync();

            return invertory;
;        }

        public async Task<Inventory> GetByProductAsync(string product)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(p => p.Product == product);
            return inventory;
        }
    }
}
