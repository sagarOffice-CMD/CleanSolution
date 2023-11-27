using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.StudentCQ.Commands
{
    public class PostStudent:IRequest<string>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
       



        public string? CourseName { get; set; }
       
    }

    public class PostStudentHandler : IRequestHandler<PostStudent, string>
    {
        private readonly IApplicationDbContext _DbContext;
        public PostStudentHandler(IApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<string> Handle(PostStudent request, CancellationToken cancellationToken)
        {
            Student student = new()
            {
                Name = request.Name,
                Email = request.Email,
               

            };
            Course course = new Course()
            {
                CourseName = request.CourseName
            };
          

            _DbContext.Student.Add(student);
            _DbContext.Course.Add(course);

            await _DbContext.savechanges();
            return "Posted complete";
        }

    }


}
