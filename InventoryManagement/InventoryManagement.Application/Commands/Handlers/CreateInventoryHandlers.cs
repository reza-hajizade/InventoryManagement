using InventoryManagement.Domain.Repositories;
using MediatR;
using InventoryManagement.Infrastructure.UnitOfWork;
using InventoryManagement.Application.Exceptions;
using InventoryManagement.Domain.Entities;


namespace InventoryManagement.Application.Commands.Handlers
{
    public class CreateInventoryHandlers : IRequestHandler<CreateInventoryCommand>
    {

        private readonly IInventoryManagementRepository _inventoryManagementRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateInventoryHandlers(IInventoryManagementRepository inventoryManagementRepository,
            IUnitOfWork unitOfWork)
        {
            _inventoryManagementRepository = inventoryManagementRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateInventoryCommand command, CancellationToken cancellationToken)
        {
            var existingInvertory =await _inventoryManagementRepository.GetByProductAsync(command.Product);

            if (existingInvertory != null)
            {
                throw new InventoryAlreadyExistException();
            }



            var newInventory = Inventory.Create(command.Product, command.Stock);
            await _inventoryManagementRepository.AddAsync(newInventory);
            await _unitOfWork.SaveChangeAsync();

        }
    }
}
