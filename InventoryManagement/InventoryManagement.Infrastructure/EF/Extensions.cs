using InventoryManagement.Application.Repositories;
using InventoryManagement.Domain.Repositories;
using InventoryManagement.Infrastructure.EF.Context;
using InventoryManagement.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EF
{
    public static class Extensions
    {

        public static IServiceCollection AddSQLDB(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddScoped<IInventoryWriteRepository, InventoryWriteRepository>();  
            services.AddScoped<IInventoryReadRepository, InventoryReadRepository>();


            services.AddDbContext<WriteDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("SvcDbContext")));


            services.AddDbContext<ReadDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("SvcDbContext")));


            return services;
        }

    }
}
