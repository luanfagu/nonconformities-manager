using TesteQualyteam.Domain.Common;

namespace TesteQualyteam.Domain.Entities
{
    public class Action: AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int NonConformityId { get; set; }

        public NonConformity NonConformity { get; set; }
    }
}