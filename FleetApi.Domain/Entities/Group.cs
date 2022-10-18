namespace FleetApi.Domain.Entities
{
    public class Group
    {
        public int Id {get;private set;}
        public string Name {get;private set;}
        public virtual IEnumerable<Equipment> equipment {get;set;}
        public Group(string name, int id)
        {
            Id = id;
            Name = name;
        }
    }
}