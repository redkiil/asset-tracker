using FleetApi.Application.DTOS;
using FleetApi.Domain.Entities;
using FluentResults;

namespace FleetApi.Application.Interfaces
{
    public interface IEquipmentService
    {
         Task<IEnumerable<EquipmentDTO>> GetAll();
         Task<EquipmentDTO> GetBy(int? fleet);

         Task<Result<EquipmentDTO>> Add(EquipmentDTO equipmentDto);
         Task Update(EquipmentDTO equipmentDto);
         Task Delete(int? fleet);
    }
}