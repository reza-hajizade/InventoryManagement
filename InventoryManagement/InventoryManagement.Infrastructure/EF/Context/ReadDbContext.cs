using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EF.Context
{
    public class ReadDbContext:DbContext
    {
        public DbSet<InventoryReadModel> inventoryReadModels { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Inventory");

            modelBuilder.Entity<InventoryReadModel>().ToTable("Inventories");
        }
    }
}
