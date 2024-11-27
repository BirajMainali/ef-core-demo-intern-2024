using Efcore_demo.Entities;
using Efcore_demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo = Efcore_demo.Entities.Todo;

namespace Efcore_demo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // This DbSet will be used to query and save instances of Todo
    public DbSet<TodoDto> Todo { get; set; }
    
}