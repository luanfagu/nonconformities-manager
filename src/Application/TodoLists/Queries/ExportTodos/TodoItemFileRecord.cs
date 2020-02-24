using TesteQualyteam.Application.Common.Mappings;
using TesteQualyteam.Domain.Entities;

namespace TesteQualyteam.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
