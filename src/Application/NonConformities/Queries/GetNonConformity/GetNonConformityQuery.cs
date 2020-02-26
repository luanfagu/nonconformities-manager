using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TesteQualyteam.Application.Common.Interfaces;
using TesteQualyteam.Application.TodoLists.Queries.GetTodos;

namespace TesteQualyteam.Application.NonConformities.Queries.GetNonConformity
{
    public class GetNonConformityQuery : IRequest<NonConformityDto>
    {
        public int Id { get; set; }

        public class GetNonConformityQueryHandler : IRequestHandler<GetNonConformityQuery, NonConformityDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetNonConformityQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<NonConformityDto> Handle(GetNonConformityQuery request, CancellationToken cancellationToken)
            {
                return await _context.NonConformities
                    .ProjectTo<NonConformityDto>(_mapper.ConfigurationProvider)
                    .Where(n => n.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}