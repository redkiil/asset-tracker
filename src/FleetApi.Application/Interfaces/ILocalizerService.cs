using FleetApi.Application.DTOS;
using FleetApi.Domain.Entities;

namespace FleetApi.Application.Interfaces
{
    public interface ILocalizerService
    {
         Location GetLocalization(Position pos);
    }
}