


using FleetApi.Domain.Interfaces;

namespace FleetApi.Data.FileSystem
{
    public class MapLoader : IMapLoader
    {
        public string LoadFile(string path)
        {
            return "{\"type\": \"FeatureCollection\", \"name\": \"MOCK_SETUP\", \"crs\": {\"type\": \"name\", \"properties\": {\"name\": \"urn:ogc:def:crs:OGC:1.3:CRS84\"}}, \"features\": [{\"type\": \"Feature\", \"properties\": {\"ID\": \"TEST\"}, \"geometry\": {\"type\": \"MultiPolygon\", \"coordinates\": [[[[-19, -52], [-19, -52], [-19, -52], [-19, -52]]]]}}]}";
        }
    }
}