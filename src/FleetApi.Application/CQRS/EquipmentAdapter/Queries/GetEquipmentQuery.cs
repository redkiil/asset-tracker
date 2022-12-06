using FleetApi.Domain.Entities;
using MediatR;

namespace FleetApi.Application.CQRS.EquipmentAdapter.Queries
{
    public class GetEquipmentQuery : IRequest<Equipment>
    {
        public int Fleet {get;set;}
        public GetEquipmentQuery(int fleet)
        {
            Fleet = fleet;
        }
    }
}