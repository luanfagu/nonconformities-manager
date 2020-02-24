using System.Collections.Generic;
using TesteQualyteam.Domain.Common;

namespace TesteQualyteam.Domain.Entities
{
    public class NonConformity: AuditableEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public IList<Action> Actions { get; set; }
    }
}