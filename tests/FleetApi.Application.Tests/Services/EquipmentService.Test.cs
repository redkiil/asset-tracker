using AutoMapper;
using FleetApi.Application.CQRS.EquipmentAdapter.Commands;
using FleetApi.Application.CQRS.EquipmentAdapter.Queries;
using FleetApi.Application.DTOS;
using FleetApi.Application.Interfaces;
using FleetApi.Application.Mappings;
using FleetApi.Application.Services;
using FleetApi.Domain.Entities;
using MediatR;
using Moq;
using Xunit;


namespace FleetApi.Application.Tests.Services;

public class EquipmentServiceTest{
    
    Mock<IMediator> _mediator;
    Mock<ILocalizerService> _locationService;
    IMapper _mapper;
    IEquipmentService _equipmentService;

    
    public EquipmentServiceTest()
    {
        _mediator = new Mock<IMediator>();
        _locationService = new Mock<ILocalizerService>();
        _locationService.Setup(x => x.GetLocalization(It.IsAny<Position>())).Returns(new Location(){});
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new DTOToCmdMapProfile()));
        _mapper = new Mapper(configuration);

        _equipmentService = new EquipmentService(_mediator.Object, _mapper, _locationService.Object);

    }
    [Fact]
    public void Should_Call_CreateCommand(){
        //Arrange
        var equipmentMock = new EquipmentDTO(){
            Id = 1234,
            Fleet = 3161,
            Model = "PUMA",
            ModelYear = 2014,
            Position = new Position(){},
            Location = new Location(){},
            Lastime = new DateTime().ToLocalTime(),
            EmployeeBadge = 4444,
            GroupId = 123,
            Data = ""
        };
        //Act
        _equipmentService.Add(equipmentMock);
        
        //Assert
        _mediator.Verify(x => x.Send(It.IsAny<EquipmentCreateCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    [Fact]
    public void Should_Call_UpdateCommand(){
        var equipmentMock = new EquipmentDTO(){};

        _equipmentService.Update(equipmentMock);

        _mediator.Verify(x => x.Send(It.IsAny<EquipmentUpdateCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    [Fact]
    public void Should_Call_DeleteCommand(){
        var fleetMock = 1234;
        _equipmentService.Delete(fleetMock);
        _mediator.Verify(x => x.Send(It.IsAny<EquipmentDeleteCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    [Fact]
    public void Should_Call_GetAllQuery(){
        _equipmentService.GetAll();

        _mediator.Verify(x => x.Send(It.IsAny<GetEquipmentsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    [Fact]
    public void Should_Call_GetByQuery(){
        var fleetMock = 1234;
        _equipmentService.GetBy(fleetMock);
        _mediator.Verify(x => x.Send(It.IsAny<GetEquipmentQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    
}