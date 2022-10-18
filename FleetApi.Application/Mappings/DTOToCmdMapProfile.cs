using AutoMapper;
using FleetApi.Application.CQRS.EquipmentAdapter.Commands;
using FleetApi.Application.DTOS;

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