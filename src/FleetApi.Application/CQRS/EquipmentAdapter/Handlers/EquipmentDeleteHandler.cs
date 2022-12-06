using FleetApi.Application.CQRS.EquipmentAdapter.Commands;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using MediatR;

namespace FleetApi.Application.CQRS.EquipmentAdapter.Handlers
{
    public class EquipmentDeleteHandler : IRequestHandler<EquipmentDeleteCommand, Equipment>
    {
        private readonly IEquipmentRepository _repository;
        public EquipmentDeleteHandler(IEquipmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Equipment> Handle(EquipmentDeleteCommand request, CancellationToken cancellationToken)
        {
            var equipment = await _repository.GetByIdAsync(request.Fleet);
            if(equipment == null)
            {
                throw new ApplicationException($"Could not found entity");
            }else{
                return await _repository.DeleteAsync(equipment);
            }
        }
    }
}