using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentCQ.Commands
{
    public class GetById : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class GEtStudenByIdHandler : IRequestHandler<GetStudentById, String>
    {
        private readonly IApplicationDbContext _DbContext;
        public GEtStudenByIdHandler(IApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<string> Handle(GetStudentById request, CancellationToken cancellationToken)
        {
            var stud = _DbContext.Student.Where(s => s.Id == request.Id).FirstOrDefaultAsync();
            await _DbContext.Student.ToListAsync();
            return "successfull";
            
            
            
        }

    }
}
