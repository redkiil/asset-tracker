using FleetApi.Application.DTOS;

namespace FleetApi.Application.Interfaces
{
    public interface IEquipmentService
    {
         Task<IEnumerable<EquipmentDTO>> GetAll();
         Task<EquipmentDTO> GetBy(int? fleet);

         Task Add(EquipmentDTO equipmentDto);
         Task Update(EquipmentDTO equipmentDto);
         Task Delete(int? fleet);
    }
}