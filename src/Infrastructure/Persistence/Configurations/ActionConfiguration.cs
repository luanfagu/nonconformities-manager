using TesteQualyteam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TesteQualyteam.Infrastructure.Persistence.Configurations
{
    public class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.Property(a => a.Description)
                .IsRequired();
        }
    }
}
