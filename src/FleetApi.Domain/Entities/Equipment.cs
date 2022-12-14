
using System.ComponentModel.DataAnnotations;
using FluentResults;

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
        public Equipment(int id, short fleet, string model, short modelYear, int groupId, short employeeBadge, string equipType, string data, Position pos)
        {
            Id = id;
            Fleet = fleet;
            Model = model;
            ModelYear = modelYear;
            EquipType = equipType;
            EmployeeBadge = employeeBadge;
            GroupId = groupId;
            Data = data;
            Position = pos;
        }
        public Equipment(short fleet, string model, short modelYear, int groupId, short employeeBadge, string equipType, string data)
        {
            Fleet = fleet;
            Model = model;
            ModelYear = modelYear;
            EquipType = equipType;
            EmployeeBadge = employeeBadge;
            GroupId = groupId;
            Data = data;
        }
        public static Result<Equipment> Create(short fleet, string model, short modelYear, int groupId, short employeeBadge, string equipType, string data)
        {
            var validationResult = Validation(fleet, model, modelYear, groupId, employeeBadge, equipType, data);
            return validationResult.IsFailed ? Result.Fail(validationResult.Errors) : Result.Ok(new Equipment(fleet, model, modelYear, groupId, employeeBadge, equipType, data));
        }
        public static Result<Equipment> Update(int id, short fleet, string model, short modelYear, int groupId, short employeeBadge, string equipType, string data, Position pos)
        {
            var validationResult = Validation(fleet, model, modelYear, groupId, employeeBadge, equipType, data);
            return validationResult.IsFailed ? Result.Fail(validationResult.Errors) : Result.Ok(new Equipment(id, fleet, model, modelYear, groupId, employeeBadge, equipType, data, pos));
        }
        public static Result Validation(short fleet, string model, short modelYear, int groupId, short employeeBadge, string equipType, string data)
        {
            var result = new Result();
            if(fleet < 1000)result.WithError("invalid fleet");
            if(String.IsNullOrEmpty(model))result.WithError("invalid model name");
            if(modelYear < 1990)result.WithError("invalid model year");
            if(groupId < 1)result.WithError("invalid group id");
            if(employeeBadge < 1000)result.WithError("invalid employee badge");
            return result;
        }
    }
}