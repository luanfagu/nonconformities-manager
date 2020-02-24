using TesteQualyteam.Application.Common.Interfaces;
using System;

namespace TesteQualyteam.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
