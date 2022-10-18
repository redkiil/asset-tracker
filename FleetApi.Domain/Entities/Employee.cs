namespace FleetApi.Domain.Entities
{
    public class Employee
    {
        public int Id {get; private set;}
        public short Badge {get;private set;}
        public string Name {get; private set;}
        public int GroupId {get; private set;}
        public virtual Group group {get;set;}
        public virtual IEnumerable<Equipment> equipment {get;set;}
        public Employee(short badge, string name)
        {
            Badge = badge;
            Name = name;

        }
    }
}