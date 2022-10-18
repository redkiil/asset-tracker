using FleetApi.Domain.Entities;
using MediatR;

namespace FleetApi.Application.CQRS.EquipmentAdapter.Commands
{
    public class EquipmentDeleteCommand : IRequest<Equipment>
    {
        public int Fleet {get;set;}
        public EquipmentDeleteCommand(int fleet)
        {
            Fleet = fleet;
        }
    }
}