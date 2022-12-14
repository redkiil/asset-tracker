using FleetApi.Domain.Entities;
using FluentResults;
using MediatR;


namespace FleetApi.Application.CQRS.EquipmentAdapter.Commands
{
    public abstract class EquipmentCommand : IRequest<Result<Equipment>>
    {
        public short Fleet {get; set;}
        public string Model {get; set;}
        public string EquipType {get; set;}
        public short ModelYear {get; set;}
        public Position Position {get;  set;}
        public DateTime Lastime {get;  set;}
        public short EmployeeBadge {get;  set;}
        public int GroupId {get;set;}
        public string Data {get;set;}
    }
}