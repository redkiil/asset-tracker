using FleetApi.Domain.Entities;

namespace FleetApi.Domain.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment> GetByIdAsync(int? id);
        Task<Equipment> CreateAsync(Equipment equipment);
        Task<Equipment> UpdateAsync(Equipment equipment);
        Task<Equipment> DeleteAsync(Equipment equipment);
    }
}