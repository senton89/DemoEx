namespace DemoExamenTest.Models;

public class PartnerType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Partner> Partners { get; set; }
}