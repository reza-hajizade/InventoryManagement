using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Repositories;
using InventoryManagement.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EF.Repositories
{
    public class InventoryReadRepository : IInventoryReadRepository
    {
        private readonly ReadDbContext _context;

        public InventoryReadRepository(ReadDbContext context)
        {
            _context = context;
        }

        public async Task<GetInventoryDto> GetByProductAsync(string product)
        {
            var result=await _context.inventoryReadModels.FirstOrDefaultAsync(p => p.Product == product);

            return new GetInventoryDto(
                result.Product,
                result.Stock);
        }
    }
}
