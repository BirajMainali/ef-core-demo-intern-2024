using Efcore_demo.Models;

namespace Efcore_demo.Repositories.Interfaces;

public interface ITodoRepository
{
    List<TodoDto> GetAll(); 
    TodoDto GetbyId(Guid id); 
    void Delete(Guid id);
    List<TodoDto> FilterTodo(string status);
}