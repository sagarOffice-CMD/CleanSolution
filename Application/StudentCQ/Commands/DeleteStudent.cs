using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentCQ.Commands
{
    public class DeleteStudent : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class DeleteStudentHandler : IRequestHandler<DeleteStudent, String>
    {
        private readonly IApplicationDbContext _DbContext;
        public DeleteStudentHandler(IApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<string> Handle(DeleteStudent request, CancellationToken cancellationToken)
        {

            var student = await _DbContext.Student.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            if (student == null) 
                return default;

            _DbContext.Student.Remove(student);
           
            return "DELETE SUCCESFULLY";
        }
    }

            
    
}
