using FleetApi.Application.CQRS.EquipmentAdapter.Queries;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using MediatR;

namespace FleetApi.Application.CQRS.EquipmentAdapter.Handlers
{
    public class EquipmentQueryHandler : IRequestHandler<GetEquipmentQuery, Equipment>
    {
        private readonly IEquipmentRepository _repository;
        public EquipmentQueryHandler(IEquipmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Equipment> Handle(GetEquipmentQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Fleet);
        }
    }
}