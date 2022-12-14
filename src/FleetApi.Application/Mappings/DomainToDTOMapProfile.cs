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

            CreateMap<Equipment, EquipmentDTO>().AfterMap((s,d) => { d.Data = JsonSerializer.Deserialize<object>(s.Data);}).ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}