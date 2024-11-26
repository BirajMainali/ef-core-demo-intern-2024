using Efcore_demo.Data;
using Efcore_demo.Models;
using Efcore_demo.Services.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Efcore_demo.Services
{
    public class TodoService : ITodoService
    {
        private readonly ILogger<TodoService> _logger;

        private readonly ApplicationDbContext _context;
        public TodoService(ILogger<TodoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public void Create(TodoDto dto)
        {
            dto.Id = Guid.NewGuid(); 
            dto.TaskDate = DateTime.UtcNow; 
            _context.Todo.Add(dto); 
            _context.SaveChanges();
        }


    
        public void Update(TodoDto dto)
        {
            var existingTodo = _context.Todo.FirstOrDefault(todo => todo.Id == dto.Id);
            if (existingTodo != null)
            {
                existingTodo.TaskTitle = dto.TaskTitle;
                existingTodo.TaskDescription = dto.TaskDescription;
                existingTodo.TaskDate = dto.TaskDate;
                existingTodo.Status = dto.Status;
                _context.SaveChanges();
            }
            
            
            else
            {
                throw new InvalidOperationException("Todo not found.");
            }
        }

        
        public void Delete(Guid id)
        {
            var todo = _context.Todo.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _context.Todo.Remove(todo); 
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Todo not found.");
            }
        }

        public void UpdateStatus(Guid id)
        {
            var existingTodo = _context.Todo.FirstOrDefault(todo => todo.Id == id);
            if (existingTodo != null)
            {
                if (existingTodo.Status == true)
                {
                    existingTodo.Status = false;
                    _context.SaveChanges();
                }
                else
                {
                    existingTodo.Status = true;
                    _context.SaveChanges();
                }
                
            }
            else
            {
                throw new InvalidOperationException("Todo not found.");
            }

        }
    }
}