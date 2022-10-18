using System.Text.Json.Serialization;
using FleetApi.Domain.Entities;

namespace FleetApi.Application.DTOS
{
    public class GroupDTO
    {
        public int Id {get;set;}
        public string Name {get;set;}
        [JsonIgnore]
        public virtual IEnumerable<Equipment> equipment {get;set;}

    }
}