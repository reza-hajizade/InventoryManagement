using InventoryManagement.Domain.Repositories;
using InventoryManagement.Infrastructure.EF.Context;
using InventoryManagement.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagement.Infrastructure.EF.Repositories
{
    public class InventoryReadRepository : IInventoryReadRepository
    {
        private readonly ReadDbContext _context;

        public InventoryReadRepository(ReadDbContext context)
        {
            _context = context;
        }

        public async Task<InventoryReadModel> GetByProductAsync(string product)
        {
            return await _context.inventoryReadModels.FirstOrDefaultAsync(p => p.Product == product);
                            
        }
    }
}
