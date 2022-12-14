using FleetApi.Data.Context;
using FleetApi.Data.Repositories;
using FleetApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class EquipmentRepositoryTest
{
    [Fact]
    public async void Should_Test_CreateMethod_Repository()
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "AssetDatabase")
            .Options;
        using (var context = new ApplicationContext(options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            EquipmentRepository equipmentRepository = new EquipmentRepository(context);
            context.groups.Add(new Group("TESTE", 1));
            context.employees.Add(new Employee(4444, "José"));

            var result = Equipment.Create(3140, "Puma", 2014, 1, 4444, "TRATOR", "{}");
            
            var res = await equipmentRepository.CreateAsync(result.Value);

            Equipment equipment = await equipmentRepository.GetByIdAsync(3140);
            Assert.Equal(3140, equipment.Fleet);
        }
    }
    [Fact]
    public async void Should_Test_UpdateMethod_Repository()
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "AssetDatabase")
            .Options;
        using (var context = new ApplicationContext(options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            EquipmentRepository equipmentRepository = new EquipmentRepository(context);
            context.groups.Add(new Group("TESTE", 1));
            context.employees.Add(new Employee(4444, "José"));
            var resultEquipment = context.equipments.Add(new Equipment(3161, "PUMA", 2014, 1, 4444, "TRATOR", "{}"));
            var equipmentId = resultEquipment.Entity.Id;
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            var newEquipment = new Equipment(equipmentId, 3161, "CASE PUMA", 2014, 1, 4444, "TRANSBORDO", "{}", new Position(){ lat = 123, lng = 123});
            var res = await equipmentRepository.UpdateAsync(newEquipment);

            Assert.Equal(3161, res.Fleet);
            Assert.Equal("TRANSBORDO", res.EquipType);
            Assert.Equal("CASE PUMA", res.Model);
            Assert.Equal(123, res.Position.lat);
        }
    }
}