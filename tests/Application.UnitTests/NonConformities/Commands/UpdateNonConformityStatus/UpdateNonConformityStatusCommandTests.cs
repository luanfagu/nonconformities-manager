using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using TesteQualyteam.Application.NonConformities.Commands.CreateNonConformity;
using TesteQualyteam.Application.NonConformities.Commands.CreateNonConformityRevision;
using TesteQualyteam.Application.NonConformities.Commands.UpdateNonConformityStatus;
using TesteQualyteam.Domain.Enums;
using Xunit;

namespace TesteQualyteam.Application.UnitTests.Common.NonConformities.Commands.UpdateNonConformityStatus
{
    public class UpdateNonConformityStatusCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldUpdateNonConformityStatus()
        {
            var commandCreateNonConformity = new CreateNonConformityCommand()
            {
                Description = "Look that NonConformity."
            };

            var handlerCreateNonConformity = new CreateNonConformityCommand.CreateNonConformitiesCommandHandler(Context);

            var resultCreateNonConformity = await handlerCreateNonConformity.Handle(commandCreateNonConformity, CancellationToken.None);

            var entityCreateNonConformity = Context.NonConformities.Find(resultCreateNonConformity);

            var command = new UpdateNonConformityStatusCommand()
            {
                Id = entityCreateNonConformity.Id
                , Status = (int) NonConformityStatus.Effective
            };

            var handler = new UpdateNonConformityStatusCommand.UpdateNonConformityStatusCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.NonConformities.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.Status.ShouldBe(command.Status);
        }
    }
}