using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using TesteQualyteam.Domain.Entities;
using Xunit;

namespace Domain.UnitTests.Entities
{
    public class NonConformityTests
    {
        [Fact]
        public async Task Handle_ShouldGenerateCodeCorrectly()
        {
            var entityOne = new NonConformity()
            {
                Description = "Look that NonConformity."
                , Year = 2020
                , Identity = 2
                , Revision = 1
            };

            entityOne.ShouldNotBeNull();
            entityOne.GenerateCode(entityOne).ShouldBe("2020:02:01");
            
            
            var entityTwo = new NonConformity()
            {
                Description = "Look that NonConformity 2."
                , Year = 2020
                , Identity = 280
                , Revision = 0
            };

            entityTwo.ShouldNotBeNull();
            entityTwo.GenerateCode(entityTwo).ShouldBe("2020:280:00");
        }
    }
}