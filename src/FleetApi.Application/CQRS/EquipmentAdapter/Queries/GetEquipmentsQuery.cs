using FleetApi.Domain.Entities;
using MediatR;

namespace FleetApi.Application.CQRS.EquipmentAdapter.Queries
{
    public class GetEquipmentsQuery : IRequest<IEnumerable<Equipment>>
    {
        
    }
}