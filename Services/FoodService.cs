using Efcore_demo.Models;
using Efcore_demo.Services.Interfaces;
using Efcore_demo.Data;

namespace Efcore_demo.Services;

public class FoodService:IFoodService
{


    public void Create(FoodDto dto)
    {
        dto.Sn = Guid.NewGuid();
        Database.Foods.Add(dto);
    }

}