using Domain.Entities;


namespace Application.DTO
{
    public class StudentDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public List<CourseDTO> Courses { get; set; }
    }
}
