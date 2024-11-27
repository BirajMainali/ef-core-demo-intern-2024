using Efcore_demo.Data;
using Efcore_demo.Entities;
using Microsoft.AspNetCore.Mvc;
using Efcore_demo.Models; 

namespace Efcore_demo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            var todos = _context.Todos.ToList();
            return View(todos);
        }

        
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(TodoViewModel todoVM)
        {
            if (ModelState.IsValid)
            {
                var todo = new Todo
                {
                    Title = todoVM.Title,
                    Description = todoVM.Description,
                    IsCompleted = false 
                };

                _context.Todos.Add(todo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(todoVM); 
        }

        
        public IActionResult Edit(long id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            var todoVM = new TodoViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted
            };

            return View(todoVM);
        }

        [HttpPost]
        public IActionResult Edit(TodoViewModel todoVM)
        {
            if (ModelState.IsValid)
            {
                var todo = _context.Todos.FirstOrDefault(t => t.Id == todoVM.Id);
                if (todo == null)
                {
                    return NotFound();
                }

                
                todo.Title = todoVM.Title;
                todo.Description = todoVM.Description;
                todo.IsCompleted = todoVM.IsCompleted; 

                _context.Todos.Update(todo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(todoVM);
        }


       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index)); // Redirect to the index after deleting
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkAsCompleted(long id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo != null)
            {
                todo.IsCompleted = true; 
                _context.Todos.Update(todo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index)); 
        }
    }
}
