
using FleetApi.Application.Types;
using GeoJSON.Net.Feature;

namespace FleetApi.Application.Interfaces
{
    public interface IMapLoader
    {
        List<Fields> LoadGeoJson();
    }
}