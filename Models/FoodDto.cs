namespace Efcore_demo.Models;

public class FoodDto
{
    public Guid Sn { get; set; }
    public string FoodName { get; set; }
    public int Price { get; set; }
    public DateOnly ExpiryDate{ get; set; }
}