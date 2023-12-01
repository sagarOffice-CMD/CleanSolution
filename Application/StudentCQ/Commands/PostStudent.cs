using AutoMapper;
using Domain.Entities;
using Application.DTO;
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
        public AddStudentDTO AddStudentDTO { get; set; }
    }

    public class PostStudentHandler : IRequestHandler<PostStudent, string>
    {
        private readonly IApplicationDbContext _DbContext;
        private IMapper _mapper;

        public PostStudentHandler(IApplicationDbContext DbContext, IMapper mapper)
        {
            _DbContext = DbContext;
            _mapper = mapper;
        }
        public async Task<string> Handle(PostStudent request, CancellationToken cancellationToken)
        {
            //Student student = new()
            //{
            //    Name = request.Name,
            //    Email = request.Email,


            //};
            //Course course = new Course()
            //{
            //    CourseName = request.CourseName
            //};


            //_DbContext.Student.Add(student);
            //_DbContext.Course.Add(course);

            //await _DbContext.savechanges();
            //return "Posted complete";

            var result = _mapper.Map<Student>(request.AddStudentDTO);

            await _DbContext.Student.AddAsync(result);
            await _DbContext.savechanges();
            return "Posted complete";
        }


    }
}



