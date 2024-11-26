using Efcore_demo.Models;

namespace Efcore_demo.Repositories.Interfaces;

public interface IFoodRepository
{
    List<FoodDto>GetAll();

    FoodDto GetbySn(Guid id);
    void Delete(Guid id); 

}