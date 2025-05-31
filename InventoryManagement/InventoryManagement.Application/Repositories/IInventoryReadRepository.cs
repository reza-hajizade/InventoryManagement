using InventoryManagement.Application.Dto;
using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Repositories
{
    public interface IInventoryReadRepository
    {
        Task<GetInventoryDto> GetByProductAsync(string product);
    }
}
