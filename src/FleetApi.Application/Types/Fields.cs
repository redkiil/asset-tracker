using FleetApi.Application.DTOS;
using Microsoft.SqlServer.Types;

namespace FleetApi.Application.Types
{
    public class Fields
    {
        public Fields(SqlGeography geo, Location props)
        {
            geometry = geo;
            properties = props;
        }
        public SqlGeography geometry;
        public Location properties;
    }
}