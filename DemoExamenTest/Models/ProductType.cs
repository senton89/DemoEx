namespace DemoExamenTest.Models;

public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Coefficient { get; set; }
    public ICollection<ProductInfo> ProductInfos { get; set; }
}