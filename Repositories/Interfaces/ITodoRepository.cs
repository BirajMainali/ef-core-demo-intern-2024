using Efcore_demo.Entities;

namespace Efcore_demo.Repositories.Interfaces;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetAllTodoAsync();
    Task<Todo> GetTodoByIdAsync(long id);
    Task AddTodoAsync(Todo todo);
    Task UpdateTodoAsync(Todo todo);
    Task DeleteTodoAsync(long id);
}