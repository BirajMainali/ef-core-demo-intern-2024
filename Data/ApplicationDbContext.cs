using Efcore_demo.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Efcore_demo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // This DbSet will be used to query and save instances of Todo
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}