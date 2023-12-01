
using Application.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PersonCQ.Queries
{
    public class GetsStudent : IRequest<List<StudentDTO>>
    { 
    
    }

    public class GetstudentHandler : IRequestHandler<GetsStudent, List<StudentDTO>>
    {
        private readonly IApplicationDbContext _DbContext;
        private readonly IMapper _Mapper;
        public GetstudentHandler(IApplicationDbContext DbContext,IMapper mapper)
        {
            _DbContext = DbContext;
            _Mapper = mapper;
        }

        public async Task<List<StudentDTO>> Handle(GetsStudent request, CancellationToken cancellationToken)
        {
          
            return _Mapper.Map<List<StudentDTO>>( await _DbContext.Student.Include(s=>s.Courses).ToListAsync());
        }
    }
}
