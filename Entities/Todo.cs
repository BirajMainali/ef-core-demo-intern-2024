namespace Efcore_demo.Entities;

public class Todo
{
    // If we are using Entity Framework, Id becomes the primary key
    public long Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public string Description { get; set; }
}