using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Commands.Handlers;
using InventoryManagement.Domain.Repositories;
using InventoryManagement.Infrastructure.Repositories;
using InventoryManagement.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<InventoryManagementDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("SvcDbContext")));



            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddScoped<IInventoryManagementRepository, InventoryManagementRepository>();


            services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateInventoryHandlers).Assembly));

            return services;
        }
    }
}
