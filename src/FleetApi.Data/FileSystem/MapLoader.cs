using Newtonsoft.Json;
using GeoJSON.Net.Feature;
using FleetApi.Application.Interfaces;
using Microsoft.SqlServer.Types;
using GeoJSON.Net.Contrib.MsSqlSpatial;
using FleetApi.Application.Types;
using FleetApi.Application.DTOS;

namespace FleetApi.Data.FileSystem
{
    public class MapLoader : IMapLoader
    {
        private readonly object _locker;
        private readonly string _filePath;
        private List<Fields> _cachedGeoJSON = new List<Fields>();

        public MapLoader(string path)
        {
            this._locker = new object();
            this._filePath = path;
        }
        public List<Fields> LoadGeoJson()
        {
            if(_cachedGeoJSON.Count == 0)
            {
                lock(_locker)
                    if(_cachedGeoJSON.Count == 0)
                    {
                        var obj = JsonConvert.DeserializeObject<FeatureCollection>(File.ReadAllText(_filePath));
                        foreach(var e in obj.Features){
                            var feat = e.ToSqlGeography().MakeValid();
                            if(feat.EnvelopeAngle() >= 90)
                            {
                                feat = feat.ReorientObject();
                            }
                            _cachedGeoJSON.Add(new Fields(feat, new Location(){ setor = e.Properties["SETOR_TP"].ToString(), talhao = 10 }));
                        }
                    }
                        
            }
            return _cachedGeoJSON;
        }
    }
}