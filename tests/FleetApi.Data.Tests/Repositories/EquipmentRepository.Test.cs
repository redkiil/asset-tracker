using FleetApi.Data.Context;
using FleetApi.Data.Repositories;
using FleetApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class EquipmentRepositoryTest
{
    [Fact]
    public async void Test_Add()
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "MovieListDatabase")
            .Options;
        using (var context = new ApplicationContext(options))
        {
            context.groups.Add(new Group("TESTE", 1));
            context.employees.Add(new Employee(4444, "Augusto"));
            var result = Equipment.Create(3140, "Puma", 2014, 1, 4444, "TRATOR", "{}");
            context.equipments.Add(result.Value);
            context.SaveChanges();
        }

        // Use a clean instance of the context to run the test
        using (var context = new ApplicationContext(options))
        {
            EquipmentRepository equipmentRepository = new EquipmentRepository(context);
            Equipment equipment = await equipmentRepository.GetByIdAsync(3140);

            Assert.Equal(3140, equipment.Fleet);
        }
    }
}