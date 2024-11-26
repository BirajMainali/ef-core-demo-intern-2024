using System;
using System.Collections.Generic;
using System.Linq;
using Efcore_demo.Data;
using Efcore_demo.Models;
using Efcore_demo.Repositories.Interfaces;

namespace Efcore_demo.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ILogger<TodoRepository> _logger;

        private readonly ApplicationDbContext _context;
        public TodoRepository(ILogger<TodoRepository> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public List<TodoDto> GetAll()
        {
            return _context.Todo.ToList();
        }
        public List<TodoDto> FilterTodo( String status)
        {
            if (status == "pending")
            {
                return _context.Todo.Where(todo=> todo.Status==false).ToList();
            }
            else if (status == "completed")
            {
                return _context.Todo.Where(todo=> todo.Status==true).ToList();
                
            }
            else
            {
                return _context.Todo.ToList();
            }
            
        }

        public TodoDto GetbyId(Guid id)
        {
            return _context.Todo.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(Guid id)
        {
            var todo = _context.Todo.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _context.Todo.Remove(todo);
            }
        }
        

    }
}