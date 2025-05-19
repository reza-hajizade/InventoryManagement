using System.Reflection;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Repositories;
using InventoryManagement.Infrastructure.Messaging.Configuration;
using InventoryManagement.Infrastructure.Messaging.Publishers;
using InventoryManagement.Infrastructure.Repositories;
using InventoryManagement.Infrastructure.UnitOfWork;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryManagementDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("SvcDbContext")));



            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddScoped<IInventoryManagementRepository, InventoryManagementRepository>();

            services.AddScoped<IInventoryEventPublisher, InventoryEventPublisher>();


            services.AddMassTransit(configure =>
            {
                var brokerConfig = configuration.GetSection(BrokerOptions.SectionName)
                                                .Get<BrokerOptions>();
                if (brokerConfig is null)
                {
                    throw new ArgumentNullException(nameof(BrokerOptions));
                }

                configure.AddConsumers(Assembly.GetExecutingAssembly());

                configure.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(brokerConfig.Host, hostConfigure =>
                    {
                        hostConfigure.Username(brokerConfig.Username);
                        hostConfigure.Password(brokerConfig.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });


            

            return services;
        }
    }
}
