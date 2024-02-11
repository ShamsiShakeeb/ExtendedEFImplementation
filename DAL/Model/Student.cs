namespace DAL.Model
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
