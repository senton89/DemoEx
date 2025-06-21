namespace DemoExamenTest.Models;

public class SaleHistoryModelView
{
    public DateTime SaleDate { get; set; }
    public string ProductInfo { get; set; }
    public int Quantity { get; set; }
    public decimal TotalSale { get; set; }
}