using AutoMapper;
using TesteQualyteam.Application.Common.Mappings;

namespace TesteQualyteam.Application.UnitTests.Common.Mappings
{
    public class MappingTestsFixture
    {
        public MappingTestsFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = ConfigurationProvider.CreateMapper();
        }

        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }
    }
}
