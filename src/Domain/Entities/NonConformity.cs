using System.Collections.Generic;
using TesteQualyteam.Domain.Common;

namespace TesteQualyteam.Domain.Entities
{
    public class NonConformity: AuditableEntity
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Identity { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public IList<Action> Actions { get; set; }
    }
}