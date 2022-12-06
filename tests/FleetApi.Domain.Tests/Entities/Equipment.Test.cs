using FleetApi.Domain.Entities;
using Xunit;

public class EquipmentTest
{
    [Fact]
    public void Should_Create_Valid_Equipment_Entity()
    {
            var entity = Equipment.Create(3150, "Puma", 2014, 1, 7777, "TRATOR", "{}");
            Assert.True(entity.IsSuccess);

    }
    [Fact]
    public void Should_Throw_Invalid_Fleet_Exception()
    {
        var entity = Equipment.Create(315, "Puma", 2014, 1, 7777, "TRATOR", "{}");
        Assert.Equal(entity.Errors.FirstOrDefault().Message, "invalid fleet");
    }
    [Fact]
    public void Should_Blablla()
    {
        var ett = new Equipment(315, "Puma", 2014, 1, 7777, "TRATOR", "{}");
        Assert.Equal("Puma", ett.Model);
    }
    [Fact]
    public void Should_Throw_Invalid_Fleet_Model_Exception()
    {
        var entity = Equipment.Create(3150, "", 2014, 1, 7777, "TRATOR", "{}");
        Assert.Equal(entity.Errors.FirstOrDefault().Message, "invalid model name");
    }
    [Fact]
    public void Should_Throw_Invalid_Fleet_YearMnf_Exception()
    {
         var entity = Equipment.Create(3150, "Puma", 1970, 1, 7777, "TRATOR", "{}");
        Assert.Equal(entity.Errors.FirstOrDefault().Message, "invalid model year");
    }
    [Fact]
    public void Should_Throw_Invalid_Fleet_GroupId_Exception()
    {
         var entity = Equipment.Create(3150, "Puma", 2014, 0, 7777, "TRATOR", "{}");
        Assert.Equal(entity.Errors.FirstOrDefault().Message, "invalid group id");
    }
}