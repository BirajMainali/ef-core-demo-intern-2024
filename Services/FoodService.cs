using Efcore_demo.Models;
using Efcore_demo.Services.Interfaces;
using Efcore_demo.Data;

namespace Efcore_demo.Services;

public class FoodService : IFoodService
{


    public void Create(FoodDto dto)
    {
        dto.Sn = Guid.NewGuid();
        Database.Foods.Add(dto);
    }

    public void Update(FoodDto dto)
    {
        var foods = Database.Foods.FirstOrDefault(todo => todo.Sn == dto.Sn);
        if (foods != null)
        {
            foods.FoodName = dto.FoodName;
            foods.Price = dto.Price;
            foods.ExpiryDate = dto.ExpiryDate;
        }
        else
        {
            throw new InvalidOperationException("Food not found.");
        }
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

}
