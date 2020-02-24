using TesteQualyteam.Application.Common.Interfaces;

namespace TesteQualyteam.Api.IntegrationTests
{
    public class TestCurrentUserService : ICurrentUserService
    {
        public string UserId => "00000000-0000-0000-0000-000000000000";
    }
}
