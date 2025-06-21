using System;
using System.Collections.Generic;

namespace DemoExamenTest.Models;

public class Partner
{
    public int Id { get; set; }
    public int PartnerTypeId { get; set; }
    public PartnerType PartnerType { get; set; }
    public string Name { get; set; }
    public string Director { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Inn { get; set; }
    public int Rating { get; set; }
    public ICollection<Product> Products { get; set; }
}