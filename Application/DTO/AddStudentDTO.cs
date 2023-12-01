using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
     public class AddStudentDTO
     {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public List<CourseDTO> Courses { get; set; }

    }
}
