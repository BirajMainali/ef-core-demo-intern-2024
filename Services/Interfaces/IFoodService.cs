using Efcore_demo.Models;

namespace Efcore_demo.Services.Interfaces;

public interface IFoodService
{
    void Create(FoodDto dto);
    void Update(FoodDto dto);
    void Delete(Guid id); 

}