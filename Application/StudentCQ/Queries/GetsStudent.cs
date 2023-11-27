using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PersonCQ.Queries
{
    public class GetsStudent : IRequest<List<Student>>
    { 
    
    }

    public class GetstudentHandler : IRequestHandler<GetsStudent, List<Student>>
    {
        private readonly IApplicationDbContext _DbContext;
        public GetstudentHandler(IApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<List<Student>> Handle(GetsStudent request, CancellationToken cancellationToken)
        {
            
            return await _DbContext.Student.ToListAsync();
        }
    }
}
