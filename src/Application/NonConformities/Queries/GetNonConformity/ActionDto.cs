using AutoMapper;
using TesteQualyteam.Application.Common.Mappings;
using TesteQualyteam.Application.TodoLists.Queries.GetTodos;
using TesteQualyteam.Domain.Entities;

namespace TesteQualyteam.Application.NonConformities.Queries.GetNonConformity
{
    public class ActionDto : IMapFrom<Action>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Action, ActionDto>()
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => (int)s.Id));
        }
    }
}