using Efcore_demo.DTOs;
using Efcore_demo.Entities;
using Efcore_demo.Repositories.Interfaces;
using Efcore_demo.ViewModels;

namespace Efcore_demo.Services;

public class TodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<TodoVm>> GetTodoAsync()
    {
        var todos = await _todoRepository.GetAllTodoAsync();

        return todos.Select(todo => new TodoVm
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            IsCompleted = todo.IsCompleted
        });
    }

    public async Task<TodoVm> GetTodoByIdAsync(long id)
    {
        var todo = await _todoRepository.GetTodoByIdAsync(id);

        return new TodoVm
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            IsCompleted = todo.IsCompleted
        };
    }

    public async Task AddTodoAsync(TodoDto todoDto)
    {
        var todo = new Todo
        {
            Title = todoDto.Title,
            Description = todoDto.Description,
            IsCompleted = todoDto.IsCompleted
        };

        await _todoRepository.AddTodoAsync(todo);
    }

    public async Task UpdateTodoAsync(TodoVm vm)
    {
        var todo = new Todo
        {
            Id = vm.Id,
            Title = vm.Title,
            Description = vm.Description,
            IsCompleted = vm.IsCompleted
        };

        await _todoRepository.UpdateTodoAsync(todo);

    }

    public async Task DeleteTodoAsync(long id)
    {
        await _todoRepository.DeleteTodoAsync(id);
    }
}
