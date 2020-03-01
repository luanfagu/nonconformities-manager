using System;
using System.Collections.Generic;
using AutoMapper;
using TesteQualyteam.Application.Common.Mappings;
using TesteQualyteam.Domain.Entities;

namespace TesteQualyteam.Application.NonConformities.Queries.GetNonConformity
{
    public class NonConformityDto : IMapFrom<NonConformity>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NonConformity, NonConformityDto>()
                .ForMember(d => d.Code,
                    opt => opt.MapFrom(s => GenerateCode(s)));
        }

        private static string GenerateCode(NonConformity nonConformity)
        {
            return nonConformity.Year + ":" + CompleteLeft(nonConformity.Identity.ToString(), "0", 2) + ":" +
                   CompleteLeft(nonConformity.Revision.ToString(), "0", 2);
        }

        private static string CompleteLeft(string input, string character, int desiredLength)
        {
            for (int i = input.Length; i < desiredLength; i++)
            {
                input = character + input;
            }

            return input;
        }
    }
}