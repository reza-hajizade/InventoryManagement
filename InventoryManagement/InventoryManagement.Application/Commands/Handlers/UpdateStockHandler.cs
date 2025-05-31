using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repositories;
using InventoryManagement.Infrastructure.UnitOfWork;
using InventoryManagement.Shared.Contracts.Events;
using MediatR;

namespace InventoryManagement.Application.Commands.Handlers
{
    public class UpdateStockHandler : IRequestHandler<UpdateStockCommad>
    {
        private readonly IInventoryWriteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryEventPublisher _publisher;
        public UpdateStockHandler(IInventoryWriteRepository repository
            , IUnitOfWork unitOfWork
            , IInventoryEventPublisher publisher)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }

        public async Task Handle(UpdateStockCommad request, CancellationToken cancellationToken)
        {
            var inventory = await _repository.GetByProductAsync(request.Product);

            if (inventory.Stock >= request.Quantity)
            {
                await _publisher.PublishInventoryReservedEventAsync(new InventoryReservedEvent(request.Id, request.Product, DateTime.Now));
                inventory.Decreasestock(request.Quantity);

            }
            else
            {
                await _publisher.PublishInventoryFailedEventAsync(new InventoryFailedEvent(request.Id, request.Product,DateTime.Now));
            }

           await _unitOfWork.SaveChangeAsync();

        }
    }
}
