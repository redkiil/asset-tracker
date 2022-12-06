using FleetApi.Application.CQRS.EquipmentAdapter.Queries;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using MediatR;

namespace FleetApi.Application.CQRS.EquipmentAdapter.Handlers
{
    public class EquipmentsQueryHandler : IRequestHandler<GetEquipmentsQuery, IEnumerable<Equipment>>
    {
        private readonly IEquipmentRepository _repository;
        public EquipmentsQueryHandler(IEquipmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Equipment>> Handle(GetEquipmentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}