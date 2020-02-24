using TesteQualyteam.Application.Common.Interfaces;
using TesteQualyteam.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace TesteQualyteam.Application.NonConformities.Commands.CreateNonConformity
{
    public class CreateNonConformityCommand : IRequest<long>
    {
        public class CreateNonConformitiesCommandHandler : IRequestHandler<CreateNonConformityCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateNonConformitiesCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateNonConformityCommand request, CancellationToken cancellationToken)
            {
                var entity = new NonConformity
                {
                    
                };

                _context.NonConformities.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
