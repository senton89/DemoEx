namespace DemoExamenTest.Models;

public class ProductInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Article { get; set; }
    public decimal MinCost { get; set; }
    public ProductType ProductType { get; set; }
    public int ProductTypeId { get; set; }
    public ICollection<Product> Products { get; set; }
}