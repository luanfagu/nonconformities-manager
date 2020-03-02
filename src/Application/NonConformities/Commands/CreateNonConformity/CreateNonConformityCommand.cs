using System;
using System.Linq;
using TesteQualyteam.Application.Common.Interfaces;
using TesteQualyteam.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using TesteQualyteam.Domain.Enums;

namespace TesteQualyteam.Application.NonConformities.Commands.CreateNonConformity
{
    public class CreateNonConformityCommand : IRequest<int>
    {
        public string Description { get; set; }

        public class CreateNonConformitiesCommandHandler : IRequestHandler<CreateNonConformityCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateNonConformitiesCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateNonConformityCommand request, CancellationToken cancellationToken)
            {
                var lastIdentity = _context.NonConformities.Where(n => n.Year == DateTime.Now.Year)
                    .OrderByDescending(n => n.Identity).Select(n => n.Identity).FirstOrDefault();

                var entity = new NonConformity
                {
                    Description = request.Description
                    , Status = (int) NonConformityStatus.Open
                    , Year = DateTime.Now.Year
                    , Identity = lastIdentity + 1
                    , Revision = 0
                };

                _context.NonConformities.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}