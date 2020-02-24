using TesteQualyteam.Application.Common.Interfaces;
using System;

namespace TesteQualyteam.Api.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
