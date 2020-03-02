using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using TesteQualyteam.Application.NonConformities.Commands.CreateNonConformity;
using TesteQualyteam.Application.NonConformities.Commands.CreateNonConformityRevision;
using Xunit;

namespace TesteQualyteam.Application.UnitTests.Common.NonConformities.Commands.CreateNonConformityRevision
{
    public class CreateNonConformityRevisionCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistNonConformityRevision()
        {
            var commandCreateNonConformity = new CreateNonConformityCommand()
            {
                Description = "Look that NonConformity."
            };

            var handlerCreateNonConformity = new CreateNonConformityCommand.CreateNonConformitiesCommandHandler(Context);

            var resultCreateNonConformity = await handlerCreateNonConformity.Handle(commandCreateNonConformity, CancellationToken.None);
            
            var entityCreateNonConformity = Context.NonConformities.Find(resultCreateNonConformity);

            var command = new CreateNonConformityRevisionCommand()
            {
                Id = entityCreateNonConformity.Id
            };

            var handler = new CreateNonConformityRevisionCommand.CreateNonConformityRevisionCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.NonConformities.Find(result);

            entity.ShouldNotBeNull();
            entity.Description.ShouldBe(entityCreateNonConformity.Description);
            entity.Year.ShouldBe(entityCreateNonConformity.Year);
            entity.Identity.ShouldBe(entityCreateNonConformity.Identity);
            entity.Revision.ShouldBe(entityCreateNonConformity.Revision + 1);
        }
    }
}