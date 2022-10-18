using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FleetApi.Domain.Entities;

namespace FleetApi.Application.DTOS
{
    public class EquipmentDTO
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "The fleet number is required!")]
        [Range(1000,9999)]
        public short Fleet {get;set;}
        [Required(ErrorMessage = "The model name is requred!")]
        [MaxLength(30)]
        public string Model {get;set;}
        [Required(ErrorMessage = "The year model is requred!")]
        [Range(1000,9999)]
        public short ModelYear {get;set;}
        public string EquipType {get;set;}
        public Position Position {get;set;}
        public Location Location {get;set;}
        public DateTime Lastime {get;set;}
        public short EmployeeBadge {get;set;}
        public EmployeeDTO Employee {get;set;}
        public int GroupId {get;set;}
        public GroupDTO Group {get;set;}
        public object Data {get;set;}
    }
    public class Location{
        public string setor {get;set;}
        public int talhao {get;set;}

    }
}