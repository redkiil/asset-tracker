using System.Diagnostics;
using FleetApi.Application.DTOS;
using FleetApi.Application.Interfaces;
using FleetApi.Application.Types;
using FleetApi.Domain.Entities;
using GeoJSON.Net.Contrib.MsSqlSpatial;
using GeoJSON.Net.Feature;
using Microsoft.SqlServer.Types;

namespace FleetApi.Application.Services
{
    public class LocalizerService : ILocalizerService
    {
        private List<Fields> json;
        private readonly IMapLoader _mapLoader;
        public LocalizerService(IMapLoader mapLoader)
        {
            _mapLoader = mapLoader;
            
            json = _mapLoader.LoadGeoJson();
        }
        public Location GetLocalization(Position pos)
        {   
            if(pos.lat == 0)return new Location(){};

            SqlGeography ptToTest = new GeoJSON.Net.Geometry.Point(new GeoJSON.Net.Geometry.Position(pos.lng,pos.lat)).ToSqlGeography();
            foreach(var e in json){
                try{
                var test = e.geometry.STIntersects(ptToTest).Value;
                if(test){
                    return e.properties;
                }

                }catch(Exception err){
                    throw new Exception(err.Message);
                }
            };

            return new Location(){};
        }
    }
}