using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Exceptions;
using InventoryManagement.Application.Repositories;
using InventoryManagement.Domain.Repositories;
using InventoryManagement.Infrastructure.UnitOfWork;
using MediatR;

namespace InventoryManagement.Application.Queries.Handlers
{
    public class GetInventoryHandle : IRequestHandler<GetInventoryQuery, GetInventoryDto>
    {
        private readonly IInventoryReadRepository _inventoryReadRepository;

        public GetInventoryHandle(IInventoryReadRepository inventoryReadRepository
            , IUnitOfWork unitOfWork)
        {
            _inventoryReadRepository = inventoryReadRepository;
        }
        public async Task<GetInventoryDto> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
        {
            var inventory =await _inventoryReadRepository.GetByProductAsync(request.Product);
            if (inventory == null)
            {
                throw new InventoryNotFoundException();
            }

            return new GetInventoryDto(
                inventory.Product,
                inventory.Stock
                 
                );
        }
    }
}
