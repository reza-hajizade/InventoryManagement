using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Infrastructure.EF.Context;
using InventoryManagement.Infrastructure.UnitOfWork;

namespace InventoryManagement.Infrastructure.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _context;
        public UnitOfWork(WriteDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
