using FleetApi.Application.CQRS.EquipmentAdapter.Commands;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using MediatR;

namespace FleetApi.Application.CQRS.EquipmentAdapter.Handlers
{
    public class EquipmentCreateHandler : IRequestHandler<EquipmentCreateCommand, Equipment>
    {
        private readonly IEquipmentRepository _repository;
        public EquipmentCreateHandler(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Equipment> Handle(EquipmentCreateCommand request, CancellationToken cancellationToken)
        {
            var equipment = new Equipment(request.Fleet, request.Model, request.ModelYear, request.GroupId, request.EmployeeBadge, request.EquipType, request.Data);
            if(equipment == null)
            {
                throw new ApplicationException($"Failed to create Entity Equipment");
            }else{
                return await _repository.CreateAsync(equipment);
            }
        }
    }
}