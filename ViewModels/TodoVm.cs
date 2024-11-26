namespace Efcore_demo.ViewModels;

public class TodoVm
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}