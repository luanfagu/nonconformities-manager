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

        public string GenerateCode(NonConformity nonConformity)
        {
            return nonConformity.Year + ":" + CompleteLeft(nonConformity.Identity.ToString(), "0", 2) + ":" +
                   CompleteLeft(nonConformity.Revision.ToString(), "0", 2);
        }

        private string CompleteLeft(string input, string character, int desiredLength)
        {
            for (int i = input.Length; i < desiredLength; i++)
            {
                input = character + input;
            }

            return input;
        }
    }
}