using FleetApi.Domain.Entities;
using Xunit;

namespace FleetApi.Domain.Tests.Entities
{
    public class EmployeeTest
    {
        [Fact]
        public void Should_Create_New_Employee_Entity()
        {
            var entity = new Employee(1234, "Augusto");

            Assert.Equal("Augusto", entity.Name);
            Assert.Equal(1234, entity.Badge);
        }
        [Fact]
        public void Should_Throw_Exception_Invalid_Badge()
        {
            var err = Assert.Throws<Exception>(() => new Employee(124, "Augusto"));
            Assert.Equal("Crachá invalido < 1000", err.Message);
        }
        [Fact]
        public void Should_Throw_Exception_Invalid_Name()
        {
            var err = Assert.Throws<Exception>(() => new Employee(1244, ""));
            Assert.Equal("Nome vazio ou invalido.", err.Message);
        }
    }
}
