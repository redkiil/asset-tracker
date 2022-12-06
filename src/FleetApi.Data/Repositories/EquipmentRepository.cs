using System.Diagnostics;
using FleetApi.Data.Context;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

//dotnet ef --startup-project ../FleetApi.Api/ migrations add Initial
namespace FleetApi.Data.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private ApplicationContext _context;
        public EquipmentRepository(ApplicationContext context) 
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            var watch = Stopwatch.StartNew();
            var equips = await _context.equipments.Include(e => e.Group).Include(e => e.Employee).ToListAsync();
            watch.Stop();

            Console.WriteLine("Time: {0}", watch.ElapsedMilliseconds);
            return equips;
        }

        public async Task<Equipment> GetByIdAsync(int? id)
        {
            return await _context.equipments.Include(e => e.Group).Include(e => e.Employee).SingleOrDefaultAsync(e => e.Fleet == id);
        }
        public async Task<Equipment> CreateAsync(Equipment equipment)
        {
            _context.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }

        public async Task<Equipment> DeleteAsync(Equipment equipment)
        {
            _context.equipments.Remove(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }
        public async Task<Equipment> UpdateAsync(Equipment equipment)
        {
            _context.Update(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }
    }
}