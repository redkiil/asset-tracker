using AutoMapper;
using FleetApi.Application.CQRS.EquipmentAdapter.Commands;
using FleetApi.Application.CQRS.EquipmentAdapter.Queries;
using FleetApi.Application.DTOS;
using FleetApi.Application.Interfaces;
using FleetApi.Domain.Entities;
using FluentResults;
using MediatR;

namespace FleetApi.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EquipmentService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        public async Task<Result<EquipmentDTO>> Add(EquipmentDTO equipmentDto)
        {
            var equipmentCreateCmd = _mapper.Map<EquipmentCreateCommand>(equipmentDto);
            var result = await _mediator.Send(equipmentCreateCmd);
            return result.ToResult<EquipmentDTO>(v => _mapper.Map<EquipmentDTO>(v));
        }

        public async Task Delete(int? fleet)
        {
            var equipmentDeleteCmd = new EquipmentDeleteCommand(fleet.Value);
            if(equipmentDeleteCmd == null)
                throw new ApplicationException($"Entity could not be loaded for delete");
            await _mediator.Send(equipmentDeleteCmd);
        }

        public async Task<IEnumerable<EquipmentDTO>> GetAll()
        {
            var equipments = new GetEquipmentsQuery();
            if(equipments == null)
                throw new ApplicationException($"Failed to load equipments query");
            var result = await _mediator.Send(equipments);
            return _mapper.Map<IEnumerable<EquipmentDTO>>(result);
        }

        public async Task<EquipmentDTO> GetBy(int? fleet)
        {
            var equipment = new GetEquipmentQuery(fleet.Value);
            if(equipment == null)
                throw new ApplicationException($"Failed to load equipment query");
            var result = await _mediator.Send(equipment);
            return _mapper.Map<EquipmentDTO>(result);
        }

        public async Task Update(EquipmentDTO equipmentDto)
        {
            var equipmentUpdateCmd = _mapper.Map<EquipmentUpdateCommand>(equipmentDto);
            await _mediator.Send(equipmentUpdateCmd);
        }
    }
}