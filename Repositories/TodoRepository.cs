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
        public List<TodoDto> GetAll()
        {
            return Database.Todos.ToList();
        }
        public List<TodoDto> FilterTodo( String status)
        {
            if (status == "pending")
            {
                return Database.Todos.Where(todo=> todo.Status==false).ToList();
            }
            else if (status == "completed")
            {
                return Database.Todos.Where(todo=> todo.Status==true).ToList();
                
            }
            else
            {
                return Database.Todos.ToList();
            }
            
        }

        public TodoDto GetbyId(Guid id)
        {
            return Database.Todos.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(Guid id)
        {
            var todo = Database.Todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                Database.Todos.Remove(todo);
            }
        }
        

    }
}