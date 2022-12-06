using FleetApi.Domain.Entities;

namespace FleetApi.Domain.Interfaces
{
    public interface IMapLoader
    {
        string LoadFile(string path);
    }
}