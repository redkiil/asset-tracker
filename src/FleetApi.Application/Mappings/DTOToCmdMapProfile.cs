using AutoMapper;
using FleetApi.Application.CQRS.EquipmentAdapter.Commands;
using FleetApi.Application.DTOS;
using FleetApi.Domain.Entities;
using FluentResults;

namespace FleetApi.Application.Mappings
{
    public class DTOToCmdMapProfile : Profile
    {
        public DTOToCmdMapProfile()
        {
            CreateMap<EquipmentDTO, EquipmentCreateCommand>();
            CreateMap<EquipmentDTO, EquipmentUpdateCommand>();
        }
    }
}