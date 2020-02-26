﻿using System.Collections.Generic;
using TesteQualyteam.Application.Common.Mappings;
using TesteQualyteam.Domain.Entities;

namespace TesteQualyteam.Application.NonConformities.Queries.GetNonConformity
{
    public class NonConformityDto: IMapFrom<NonConformity>
    {
        public NonConformityDto()
        {
            Actions = new List<ActionDto>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public IList<ActionDto> Actions { get; set; }
    }
}