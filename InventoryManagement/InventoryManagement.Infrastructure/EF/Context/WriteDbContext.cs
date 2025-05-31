using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EF.Context
{
    public class WriteDbContext:DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Inventory");

            modelBuilder.Entity<Inventory>().ToTable("Inventories");
        }
    }
}
