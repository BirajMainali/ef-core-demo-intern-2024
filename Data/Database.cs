using Efcore_demo.Models;
using System.Collections.Generic;

namespace Efcore_demo.Data
{
    public static class Database
    {
        public static List<TodoDto> Todos { get; set; } = new List<TodoDto>(); 
    }
}