using FleetApi.Application.CQRS.EquipmentAdapter.Commands;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace FleetApi.Application.CQRS.EquipmentAdapter.Handlers
{
    public class EquipmentCreateHandler : IRequestHandler<EquipmentCreateCommand, Result<Equipment>>
    {
        private readonly IEquipmentRepository _repository;
        public EquipmentCreateHandler(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Equipment>> Handle(EquipmentCreateCommand request, CancellationToken cancellationToken)
        {
            var equipmentResult = Equipment.Create(request.Fleet, request.Model, request.ModelYear, request.GroupId, request.EmployeeBadge, request.EquipType, request.Data);
            var result = equipmentResult switch
            {
                { IsFailed: true } => Result.Fail(equipmentResult.Errors[0]),
                { IsSuccess: true } => Result.Ok(await _repository.CreateAsync(equipmentResult.Value)),
                _ => null
            };
            return result;
        }
    }
}