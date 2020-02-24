using TesteQualyteam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteQualyteam.Infrastructure.Persistence.Configurations
{
    public class NonConformityConfiguration : IEntityTypeConfiguration<NonConformity>
    {
        public void Configure(EntityTypeBuilder<NonConformity> builder)
        {            
        }
    }
}
