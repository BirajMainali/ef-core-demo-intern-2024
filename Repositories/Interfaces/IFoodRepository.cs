using Efcore_demo.Models;

namespace Efcore_demo.Repositories.Interfaces;

public interface IFoodRepository
{
    List<FoodDto>GetAll();

}