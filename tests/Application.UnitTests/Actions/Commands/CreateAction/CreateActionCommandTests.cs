using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using TesteQualyteam.Application.Actions.Commands.CreateAction;
using TesteQualyteam.Application.NonConformities.Commands.CreateNonConformity;
using Xunit;

namespace TesteQualyteam.Application.UnitTests.Common.Actions.Commands.CreateAction
{
    public class CreateActionCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistAction()
        {
            var command = new CreateActionCommand()
            {
                Description = "Look that NonConformity."
                , NonConformityId = 1
            };

            var handler = new CreateActionCommand.CreateActionCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Actions.Find(result);

            entity.ShouldNotBeNull();
            entity.Description.ShouldBe(command.Description);
            entity.NonConformityId.ShouldBe(command.NonConformityId);
        }
    }
}