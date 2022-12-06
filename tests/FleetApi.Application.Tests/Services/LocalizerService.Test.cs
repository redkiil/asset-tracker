// using System;
// using FleetApi.Application.Interfaces;
// using FleetApi.Application.Services;
// using FleetApi.Domain.Entities;
// using FleetApi.Domain.Interfaces;

// using Moq;
// using Xunit;

// namespace FleetApi.Application.Tests.Services
// {
//     public class LocalizerServiceTest
//     {
//         [Fact]
//         public void Should_Return_Talhao_Value()
//         {
//             ILocalizerService _localizerService;
//             var mapLoaderMock = new Mock<IMapLoader>();
//             mapLoaderMock.Setup(x => x.LoadFile(It.IsAny<string>())).Returns("{ 'type': 'FeatureCollection', 'features': [ { 'type': 'Feature', 'properties': { 'TALHAO': 'TESTE' }, 'geometry': { 'coordinates': [ [ [ -51.83387043599427, -19.27376908182036 ], [ -51.83387043599427, -20.30652511593084 ], [ -49.94785539242193, -20.30652511593084 ], [ -49.94785539242193, -19.27376908182036 ], [ -51.83387043599427, -19.27376908182036 ] ] ], 'type': 'Polygon' } } ] }");
//             var positionMock = new Position(){
//                 lat = -50,
//                 lng = -19.5
//             };
//             _localizerService = new LocalizerService(mapLoaderMock.Object);

//             var location = _localizerService.GetLocalization(positionMock);

//             Assert.Equal("TESTE", location.setor);
//         }
//         [Fact]
//         public void Should_Return_Empty()
//         {
//             ILocalizerService _localizerService;
//             var mapLoaderMock = new Mock<IMapLoader>();
//             mapLoaderMock.Setup(x => x.LoadFile(It.IsAny<string>())).Returns("{ 'type': 'FeatureCollection', 'features': [ { 'type': 'Feature', 'properties': { 'TALHAO': 'TESTE' }, 'geometry': { 'coordinates': [ [ [ -51.83387043599427, -19.27376908182036 ], [ -51.83387043599427, -20.30652511593084 ], [ -49.94785539242193, -20.30652511593084 ], [ -49.94785539242193, -19.27376908182036 ], [ -51.83387043599427, -19.27376908182036 ] ] ], 'type': 'Polygon' } } ] }");
//             var positionMock = new Position(){
//                 lat = -50,
//                 lng = -13.5
//             };
//             _localizerService = new LocalizerService(mapLoaderMock.Object);

//             var location = _localizerService.GetLocalization(positionMock);

//             Assert.Null(location.setor);
//         }
//         [Fact]
//         public void Should_Throw_Exception()
//         {
//             ILocalizerService _localizerService;
//             var mapLoaderMock = new Mock<IMapLoader>();
//             mapLoaderMock.Setup(x => x.LoadFile(It.IsAny<string>())).Returns("{ 'type': 'FeatureCollection', 'features': [ { 'type': 'Feature', 'properties': { 'TALHAO': 'TESTE' }, 'geometry': { 'coordinates': [ [ [ -51.83387043599427, -19.27376908182036 ], [ -51.83387043599427, -20.30652511593084 ], [ -49.94785539242193, -20.30652511593084 ], [ -49.94785539242193, -19.27376908182036 ], [ -51.83387043599427, -19.27376908182036 ] ] ], 'type': 'Polygon' } } ] }");
//             var positionMock = new Position(){
//                 lat = -50,
//                 lng = -999.5
//             };
//             _localizerService = new LocalizerService(mapLoaderMock.Object);

//             Assert.ThrowsAny<Exception>(() => _localizerService.GetLocalization(positionMock));
//         }
//     }
// }