using FleetApi.Domain.Entities;
using MediatR;


namespace FleetApi.Application.CQRS.EquipmentAdapter.Commands
{
    public abstract class EquipmentCommand : IRequest<Equipment>
    {
        public short Fleet {get;private set;}
        public string Model {get;private set;}
        public string EquipType {get;private set;}
        public short ModelYear {get;private set;}
        public Position Position {get; private set;}
        public DateTime Lastime {get; private set;}
        public short EmployeeBadge {get; private set;}
        public int GroupId {get;set;}
        public string Data {get;set;}
    }
}