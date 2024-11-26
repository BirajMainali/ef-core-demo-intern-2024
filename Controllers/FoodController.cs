using Efcore_demo.Data;
using Efcore_demo.Models;
using Efcore_demo.Repositories.Interfaces;
using Efcore_demo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Efcore_demo.Controllers;

public class FoodController : Controller
{
    public FoodController(
        IFoodService foodService,
        IFoodRepository foodRepository


    )
    {
        _foodService = foodService;
        _foodRepository = foodRepository;
    }

    public IFoodService _foodService { get; }
    public IFoodRepository _foodRepository { get; }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(FoodVm vm)
    {
        if (ModelState.IsValid)
        {
            var dto = new FoodDto()
            {
                FoodName = vm.FoodName,
                Price = vm.Price

            };
            _foodService.Create(dto);
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Update(Guid id)
    {
        var foods = _foodRepository.GetbySn(id);
        if (foods == null)
        {
            return NotFound();
        }

        return View((FoodDto)foods);
    }

    [HttpPost]
    public IActionResult Update(FoodDto dto)
    {
        if (ModelState.IsValid)
        {
            _foodService.Update(dto);
            return RedirectToAction("GetFoods");
        }

        return View(dto);
    }

    public IActionResult Delete(Guid id)
    {
        var todo = Database.Foods.FirstOrDefault(t => t.Sn == id);
        FoodDto food = null;
        if (food != null)
        {
            Database.Foods.Remove(food);
            return RedirectToAction("GetFoods");
        }
        else
        {
            return NotFound();
        }


    }
}
    