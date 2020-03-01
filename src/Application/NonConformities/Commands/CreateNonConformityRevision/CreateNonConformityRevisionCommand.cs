using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TesteQualyteam.Application.Common.Interfaces;
using TesteQualyteam.Application.NonConformities.Commands.CreateNonConformity;
using TesteQualyteam.Domain.Entities;
using TesteQualyteam.Domain.Enums;

namespace TesteQualyteam.Application.NonConformities.Commands.CreateNonConformityRevision
{
    public class CreateNonConformityRevisionCommand : IRequest<long>
    {
        public int Id { get; set; }

        public class CreateNonConformityRevisionCommandHandler : IRequestHandler<CreateNonConformityRevisionCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateNonConformityRevisionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateNonConformityRevisionCommand request, CancellationToken cancellationToken)
            {
                var baseNonConformity = await _context.NonConformities.FindAsync(request.Id);

                var entity = new NonConformity
                {
                    Description = baseNonConformity.Description
                    , Status = (int)NonConformityStatus.Open
                    , Year = baseNonConformity.Year
                    , Identity = baseNonConformity.Identity
                    , Revision = baseNonConformity.Revision + 1
                };

                _context.NonConformities.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}