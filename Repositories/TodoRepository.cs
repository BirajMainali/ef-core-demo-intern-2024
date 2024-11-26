using Efcore_demo.Data;
using Efcore_demo.Entities;
using Efcore_demo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Efcore_demo.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;

    public TodoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Todo>> GetAllTodoAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo> GetTodoByIdAsync(long id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task AddTodoAsync(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTodoAsync(Todo todo)
    {
        _context.Todos.Update(todo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTodoAsync(long id)
    {
        var todo = await GetTodoByIdAsync(id);
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
    }
}