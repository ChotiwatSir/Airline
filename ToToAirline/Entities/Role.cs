namespace ToToAirline.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}