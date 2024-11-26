using Efcore_demo.DTOs;
using Efcore_demo.Services;
using Efcore_demo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Efcore_demo.Controllers;

public class TodoController : Controller
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    // Get all the todo item
    public async Task<IActionResult> Index()
    {
        var todos = await _todoService.GetTodoAsync();
        return View(todos);
    }
    
    // show create todo form
    public IActionResult Create()
    {
        return View(new TodoDto());
    }
    
    // Handle 'Create' form submission
    [HttpPost]
    public async Task<IActionResult> Create(TodoDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        await _todoService.AddTodoAsync(dto);
        return RedirectToAction("Index", "Todo");
    }
    
    // Show Edit form
    public async Task<IActionResult> Edit(long id)
    {
        var todo = await _todoService.GetTodoByIdAsync(id);
        return View(todo);
    }
    
    // Handle Edit post method
    [HttpPost]
    public async Task<IActionResult> Edit(TodoVm vm)
    {
        if (!ModelState.IsValid) return View(vm);

        await _todoService.UpdateTodoAsync(vm);
        return RedirectToAction("Index", "Todo");
    }
    
    // Delete
    public async Task<IActionResult> Delete(long id)
    {
        await _todoService.DeleteTodoAsync(id);
        return RedirectToAction("Index", "Todo");
    }
}