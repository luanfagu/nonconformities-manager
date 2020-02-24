using TesteQualyteam.Application.Common.Mappings;
using TesteQualyteam.Domain.Entities;
using System.Collections.Generic;

namespace TesteQualyteam.Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
}
