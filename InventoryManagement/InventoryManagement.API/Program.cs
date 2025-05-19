using InventoryManagement.Application.Commands.Handlers;
using InventoryManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateInventoryHandlers).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(UpdateStockHandler).Assembly);
});


ConfigurationManager configuration = builder.Configuration;

builder.Services.AddApplicationServices(configuration);

builder.Services.AddControllers();





builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
