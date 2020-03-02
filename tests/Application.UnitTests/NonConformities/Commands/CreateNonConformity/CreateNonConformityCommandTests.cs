using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using TesteQualyteam.Application.NonConformities.Commands.CreateNonConformity;
using Xunit;

namespace TesteQualyteam.Application.UnitTests.Common.NonConformities.Commands.CreateNonConformity
{
    public class CreateNonConformityCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistNonConformity()
        {
            var command = new CreateNonConformityCommand()
            {
                Description = "Look that NonConformity."
            };

            var handler = new CreateNonConformityCommand.CreateNonConformitiesCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.NonConformities.Find(result);

            entity.ShouldNotBeNull();
            entity.Description.ShouldBe(command.Description);
        }
    }
}