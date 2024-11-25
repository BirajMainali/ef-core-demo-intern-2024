using Efcore_demo.Data;
using Efcore_demo.Models;
using Efcore_demo.Repositories.Interfaces;

namespace Efcore_demo.Repositories;

public class FoodRepository:IFoodRepository
{
    public List<FoodDto> GetAll()
    {
        return Database.Foods.ToList();
    }

    public FoodDto GetbyId(Guid id)
    {
        return Database.Foods.FirstOrDefault(t => t.Sn== id);
    }
}
