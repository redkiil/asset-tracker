using FleetApi.Application.DTOS;
using FleetApi.Application.Interfaces;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using GeoJSON.Net.Contrib.MsSqlSpatial;
using GeoJSON.Net.Feature;
using Microsoft.SqlServer.Types;
using Newtonsoft.Json;

namespace FleetApi.Application.Services
{
    public class LocalizerService : ILocalizerService
    {
        private FeatureCollection json;
        private readonly IMapLoader _mapLoader;
        public LocalizerService(IMapLoader mapLoader)
        {
            _mapLoader = mapLoader;
            json = JsonConvert.DeserializeObject<FeatureCollection>(_mapLoader.LoadFile(""));
        }
        public Location GetLocalization(Position pos)
        {
            SqlGeography ptToTest = new GeoJSON.Net.Geometry.Point(new GeoJSON.Net.Geometry.Position(pos.lng,pos.lat)).ToSqlGeography();
            foreach(var e in json.Features){
                try{
                SqlGeography poly = e.ToSqlGeography().MakeValid();
                if(poly.EnvelopeAngle() >= 90)
                {
                    poly = poly.ReorientObject();
                }
                var test = poly.STIntersects(ptToTest).Value;
                if(test){
                    var data = e.Properties.ToList();
                    return new Location(){setor = (string)data[0].Value, talhao = 10};
                }
                }catch(Exception err){
                    throw new Exception(err.Message);
                }
            };
            return new Location(){};
        }
    }
}