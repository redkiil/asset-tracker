using FleetApi.Application.CQRS.EquipmentAdapter.Commands;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace FleetApi.Application.CQRS.EquipmentAdapter.Handlers
{
    public class EquipmentUpdateHandler : IRequestHandler<EquipmentUpdateCommand, Result<Equipment>>
    {
        private readonly IEquipmentRepository _repository;
        public EquipmentUpdateHandler(IEquipmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Equipment>> Handle(EquipmentUpdateCommand request, CancellationToken cancellationToken)
        {
            var equipment = await _repository.GetByIdAsync(request.Fleet);
            if(equipment == null)
            {
                return Result.Fail("Equipment invalid");
            }else{
                var result = await _repository.UpdateAsync(equipment);
                return Result.Ok(result);
            }
        }
    }
}