using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Exceptions;
using InventoryManagement.Domain.Repositories;
using InventoryManagement.Infrastructure.UnitOfWork;
using MediatR;

namespace InventoryManagement.Application.Queries.Handlers
{
    public class GetInventoryHandle : IRequestHandler<GetInventoryQuery, GetInventoryDto>
    {
        private readonly IInventoryManagementRepository _inventoryManagementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetInventoryHandle(IInventoryManagementRepository inventoryManagementRepository
            , IUnitOfWork unitOfWork)
        {
            _inventoryManagementRepository = inventoryManagementRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<GetInventoryDto> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
        {
            var inventory =await _inventoryManagementRepository.GetByProductAsync(request.Product);
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
