using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FleetApi.Domain.Entities
{
    [Keyless]
    public class Position
    {
        public double lat {get;set;}
        public double lng {get;set;}
    }
}