using Microsoft.AspNetCore.Mvc;
using Efcore_demo.Data;
using Efcore_demo.Models;
using Efcore_demo.Repositories.Interfaces;
using Efcore_demo.Services.Interfaces;

namespace TodoApplication.Controllers;

public class TodoController : Controller
{
    public TodoController(
       ITodoService todoService,
       ITodoRepository todoRepository
    )
    {
        _todoService = todoService;
        _todoRepository = todoRepository;

    }
    public ITodoService _todoService { get; }
    public ITodoRepository _todoRepository { get; }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(TodoVm vm)
    {
        if (ModelState.IsValid)
        {
            var dto = new TodoDto
            {
                TaskTitle = vm.TaskTitle,
                TaskDescription = vm.TaskDescription
            };
            _todoService.Create(dto); 

            return RedirectToAction("GetTodos"); 
        }

        return View(vm); 
    }
    
    public IActionResult GetTodos()
    {
        var todos = _todoRepository.GetAll();
        return View(todos);
    }
    [HttpPost]
    public IActionResult GetTodos(string status)
    {
        var todos = _todoRepository.FilterTodo(status);
        return View(todos);
    }

    public IActionResult Update(Guid id)
    {
        var todo = _todoRepository.GetbyId(id);

        if (todo == null)
        {
            return NotFound();
        }

       
        return View((TodoDto)todo);
    }
    [HttpPost]
    public IActionResult Update(TodoDto dto)
    {
        if (ModelState.IsValid)
        {
            _todoService.Update(dto);
            return RedirectToAction("GetTodos");
        }

        return View(dto); 
    }

    

    public IActionResult Delete(Guid id)
    {
        
        if (id != null)
        {
            _todoService.Delete(id);
            return RedirectToAction("GetTodos");
        }
        else
        {
            return NotFound();
        }
        
    }
    
    public IActionResult TodoStatus(Guid id)
    {
        if (id!=null)
        {
            _todoService.UpdateStatus(id);
        }

        return RedirectToAction("GetTodos");
    }

    
    
    

}