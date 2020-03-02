using AutoMapper;
using TesteQualyteam.Domain.Entities;
using System;
using TesteQualyteam.Application.NonConformities.Queries.GetNonConformity;
using Xunit;
using Action = TesteQualyteam.Domain.Entities.Action;

namespace TesteQualyteam.Application.UnitTests.Common.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Theory]
        [InlineData(typeof(NonConformity), typeof(NonConformityDto))]
        [InlineData(typeof(Action), typeof(ActionDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
