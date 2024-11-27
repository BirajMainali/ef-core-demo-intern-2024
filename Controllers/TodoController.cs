using Efcore_demo.Data;
using Efcore_demo.Entities;
using Microsoft.AspNetCore.Mvc;
using Efcore_demo.Models; // Assuming we create a TodoViewModel

namespace Efcore_demo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ: Show list of todos
        public IActionResult Index()
        {
            var todos = _context.Todos.ToList();
            return View(todos);
        }

        // CREATE: Show create todo form
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Save new todo
        [HttpPost]
        public IActionResult Create(TodoViewModel todoVM)
        {
            if (ModelState.IsValid)
            {
                var todo = new Todo
                {
                    Title = todoVM.Title,
                    Description = todoVM.Description,
                    IsCompleted = false // Default to false when creating a new todo
                };

                _context.Todos.Add(todo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(todoVM); // If model validation fails, return with the same data
        }

        // EDIT: Show edit form for a specific todo
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

                // Update the fields including the IsCompleted checkbox
                todo.Title = todoVM.Title;
                todo.Description = todoVM.Description;
                todo.IsCompleted = todoVM.IsCompleted;  // This will update the completion status

                _context.Todos.Update(todo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(todoVM);
        }


        // DELETE: Delete a specific todo
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

        // MARK AS COMPLETED: Toggle completion status of a todo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkAsCompleted(long id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo != null)
            {
                todo.IsCompleted = true; // Mark as completed
                _context.Todos.Update(todo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index)); // Redirect to the index after marking as completed
        }
    }
}
