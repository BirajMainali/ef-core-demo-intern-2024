namespace Efcore_demo.Models;

public class FoodVm
{
    public string FoodName { get; set; }
    public int Price { get; set; }
    public DateOnly ExpiryDate{ get; set; }
}