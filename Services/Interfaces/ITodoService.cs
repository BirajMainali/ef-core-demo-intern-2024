using Efcore_demo.Models;

namespace Efcore_demo.Services.Interfaces;

public interface ITodoService
{
    void Create(TodoDto dto); 
    void Update(TodoDto dto); 
    void Delete(Guid id);
    void UpdateStatus(Guid id);
}