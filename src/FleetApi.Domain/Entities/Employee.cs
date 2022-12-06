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
            ValidateEmployee(badge, name);
        }
        private void ValidateEmployee(short badge, string name)
        {
            if(String.IsNullOrEmpty(name))throw new Exception("Nome vazio ou invalido.");
            if(badge < 1000)throw new Exception("Crachá invalido < 1000");
            Badge = badge;
            Name = name;
        }
    }
}