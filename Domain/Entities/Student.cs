using Domain.Common;

namespace Domain.Entities
{
    public class Student : Auditable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
       
        public List<Course>? Courses { get; set; }
    }
}
