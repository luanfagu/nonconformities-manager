using TesteQualyteam.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace TesteQualyteam.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
