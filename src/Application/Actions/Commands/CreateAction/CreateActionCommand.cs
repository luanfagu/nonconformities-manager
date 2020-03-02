using TesteQualyteam.Application.Common.Interfaces;
using TesteQualyteam.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace TesteQualyteam.Application.Actions.Commands.CreateAction
{
    public class CreateActionCommand : IRequest<int>
    {
        public int NonConformityId { get; set; }

        public string Description { get; set; }

        public class CreateActionCommandHandler : IRequestHandler<CreateActionCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateActionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateActionCommand request, CancellationToken cancellationToken)
            {
                var entity = new Action
                {
                    NonConformityId = request.NonConformityId
                    , Description = request.Description
                };

                _context.Actions.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
