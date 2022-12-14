


using FleetApi.Application.CQRS.EquipmentAdapter.Commands;
using FleetApi.Application.CQRS.EquipmentAdapter.Handlers;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using MediatR;
using Moq;
using Xunit;

#nullable disable

public class EquipmentHandlerTest
{
    [Fact]
    public void Should_Call_EquipmentCreate_Handler_ReturnFailed()
    {
        var _equipmentRepository = new Mock<IEquipmentRepository>();

        var equipmentRequest = new EquipmentCreateCommand(){
            Fleet = 124,
            ModelYear = 2014,
            EmployeeBadge = 4444,
            GroupId = 1,
            Data = "{}",
            Model = "PUMA",
        };

        var equipmentHandler = new EquipmentCreateHandler(_equipmentRepository.Object);

        var result = equipmentHandler.Handle(equipmentRequest, CancellationToken.None);

        Assert.True(result.Result.IsFailed);
        Assert.Equal("invalid fleet", result.Result.Errors[0].Message);
    }
    [Fact]
    public void Should_Call_EquipmentCreate_Handler_ReturnIsSuccess()
    {
        var _equipmentRepository = new Mock<IEquipmentRepository>();

        var equipmentRequest = new EquipmentCreateCommand(){
            Fleet = 1234,
            ModelYear = 2014,
            EmployeeBadge = 4444,
            GroupId = 1,
            Data = "{}",
            Model = "PUMA",
        };

        var equipmentHandler = new EquipmentCreateHandler(_equipmentRepository.Object);

        var result = equipmentHandler.Handle(equipmentRequest, CancellationToken.None);

        Assert.True(result.Result.IsSuccess);
    }
    [Fact]
    public void Should_Call_EquipmentUpdate_Handler_ReturnIsSuccess()
    {
        var _equipmentRepository = new Mock<IEquipmentRepository>();
        var eqpReq = new EquipmentUpdateCommand(){
            Fleet = 1234,
            ModelYear = 2014,
            EmployeeBadge = 4444,
            GroupId = 1,
            Data = "{}",
            Model = "PUMA",
        };
        _equipmentRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult<Equipment>(new Equipment(eqpReq.Fleet, eqpReq.Model, eqpReq.ModelYear, eqpReq.GroupId, eqpReq.EmployeeBadge, eqpReq.EquipType, eqpReq.Data)));
            
        var equipmentHandler = new EquipmentUpdateHandler(_equipmentRepository.Object);

        var result = equipmentHandler.Handle(eqpReq, CancellationToken.None);

        Assert.True(result.Result.IsSuccess);
    }
    [Fact]
    public void Should_Call_EquipmentUpdate_Handler_ReturnIsFailed()
    {
        var _equipmentRepository = new Mock<IEquipmentRepository>();
        var eqpReq = new EquipmentUpdateCommand(){
            Fleet = 1234,
            ModelYear = 2014,
            EmployeeBadge = 4444,
            GroupId = 1,
            Data = "{}",
            Model = "PUMA",
        };
        _equipmentRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult<Equipment>(null));
            
        var equipmentHandler = new EquipmentUpdateHandler(_equipmentRepository.Object);

        var result = equipmentHandler.Handle(eqpReq, CancellationToken.None);

        Assert.True(result.Result.IsFailed);
    }
}