using System.Text.Json;
using AutoMapper;
using FleetApi.Application.DTOS;
using FleetApi.Application.Interfaces;
using FleetApi.Domain.Entities;

namespace FleetApi.Application.Mappings
{
    public class DomainToDTOMapProfile : Profile
    {
        public DomainToDTOMapProfile()
        {

            CreateMap<Equipment, EquipmentDTO>().AfterMap((s,d) => { d.Data = JsonSerializer.Deserialize<object>(s.Data);}).AfterMap<LocationMapperAction>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
    public class LocationMapperAction : IMappingAction<Equipment, EquipmentDTO>
    {
        private ILocalizerService _localizer;
        public LocationMapperAction(ILocalizerService localizer)
        {
            _localizer = localizer;
        }
        public void Process(Equipment source, EquipmentDTO destination, ResolutionContext context)
        {
            destination.Location = _localizer.GetLocalization(source.Position);
        }
    }
}