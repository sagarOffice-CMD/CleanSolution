using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentCQ.Commands
{
    public class GetStudentById : IRequest<String>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        
        

        public string? CourseName { get; set; }

    }
    public class PutStudentHandler : IRequestHandler<GetStudentById, String>
    {
        private readonly IApplicationDbContext _DbContext;
        public PutStudentHandler(IApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<string> Handle(GetStudentById request, CancellationToken cancellationToken)
        {
           
            var student = _DbContext.Student.Where(a => a.Id == request.Id).FirstOrDefault();

            if (student == null)
            {
                return "Null Value ";
            }
            else
            {
               
                student.Id = request.Id;
                student.Name = request.Name;              
                student.Courses = new List<Course>
                {
                    new()
                    {
                        CourseName= request.CourseName,
                        StudentId=request.Id
                    }
                };

               
            }
            await _DbContext.savechanges();
            return "Update Sucessfull";

        }
    }
}
 