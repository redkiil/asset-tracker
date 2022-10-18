using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace FleetApi.Domain.Entities
{
    public class Equipment
    {
        public int Id {get;private set;}
        public short Fleet {get;private set;}
        public string Model {get;private set;}
        public string EquipType {get;private set;}
        public short ModelYear {get;private set;}
        public Position Position {get; private set;} = new Position{lat = 0, lng = 0};
        public DateTime Lastime {get; private set;}
        public short EmployeeBadge {get; private set;}
        public Employee Employee {get; set;}
        public int GroupId {get;set;}
        public Group Group {get;set;}
        public string Data {get;private set;} = "{}";

        public Equipment(short fleet, string model, short modelYear, int groupId, short employeeBadge, string equipType, string data)
        {
            ValidateEquipment(fleet, model, modelYear, groupId, employeeBadge, equipType, data);
        }
        public void Update(short fleet, string model, short modelYear, int groupId, short employeeBadge, Position pos, DateTime time, string data, string equipType)
        {
            ValidateEquipment(fleet, model, modelYear, groupId, employeeBadge, equipType, data);

            Fleet = fleet;
            Model = model;
            ModelYear = modelYear;
            Position = pos;
            Lastime = time;
            EquipType = equipType;
            EmployeeBadge = employeeBadge;
            GroupId = groupId;
            Data = data;
        }
        private void ValidateEquipment(short fleet, string model, short modelYear, int groupId, short employeeBadge, string equipType, string data)
        {
            // if(1000 < fleet || fleet > 9999)throw new ArgumentNullException();
            // if(String.IsNullOrEmpty(model))throw  new ArgumentNullException();
            // if(modelYear < 1990)throw new ArgumentOutOfRangeException();
            // if(groupId < 1)throw new ArgumentOutOfRangeException();

            Fleet = fleet;
            Model = model;
            ModelYear = modelYear;
            GroupId = groupId;
            EmployeeBadge = employeeBadge;
            EquipType = equipType;
            Data = data;
        }
    }
}