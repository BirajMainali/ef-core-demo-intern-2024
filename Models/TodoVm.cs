namespace Efcore_demo.Models;

public class TodoVm
{
    public DateTime TaskDate { get; set; }
    public string TaskTitle { get; set; }
    public string TaskDescription { get; set; }
    public bool Status { get; set; }
}