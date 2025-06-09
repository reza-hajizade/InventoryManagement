using InventoryManagement.Infrastructure.EF.Models;


namespace InventoryManagement.Domain.Repositories
{
    public interface IInventoryReadRepository
    {
        Task<InventoryReadModel> GetByProductAsync(string product);
    }
}
