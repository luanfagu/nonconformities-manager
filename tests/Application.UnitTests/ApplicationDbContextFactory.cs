using TesteQualyteam.Application.Common.Interfaces;
using TesteQualyteam.Domain.Entities;
using TesteQualyteam.Infrastructure.Persistence;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using Action = TesteQualyteam.Domain.Entities.Action;

namespace TesteQualyteam.Application.UnitTests.Common
{
    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var currentUserServiceMock = new Mock<ICurrentUserService>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns("00000000-0000-0000-0000-000000000000");

            var context = new ApplicationDbContext(
                options, operationalStoreOptions,
                dateTimeMock.Object);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(ApplicationDbContext context)
        { 
            context.NonConformities.AddRange(
                new NonConformity() {Id = 1, Description = "NonConformity test", Year = DateTime.Now.Year, Identity = 1, Revision = 0}
                , new NonConformity() {Id = 2, Description = "NonConformity test", Year = DateTime.Now.Year, Identity = 1, Revision = 1 }
                );

            context.Actions.AddRange(
                new Action() { Id = 1, Description = "Test action 1", NonConformityId = 1}
                );

            context.SaveChanges();
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}