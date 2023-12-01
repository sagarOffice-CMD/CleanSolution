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
    public class GetById : IRequest<Student>
    {
        public int Id { get; set; }
    }
    public class GEtStudenByIdHandler : IRequestHandler<GetById,Student>
    {
        private readonly IApplicationDbContext _DbContext;
        public GEtStudenByIdHandler(IApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        

        public async Task<Student> Handle(GetById request, CancellationToken cancellationToken)
        {
            var stud = await _DbContext.Student.Where(s => s.Id == request.Id).FirstOrDefaultAsync();
            return stud;
        }
    }
}
