using System.Collections.Generic;

namespace DemoExamenTest.Models;

    public class PartnerEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Inn { get; set; }
        public int Rating { get; set; }
        public int PartnerTypeId { get; set; }
        public List<PartnerType> PartnerTypes { get; set; }
        public List<Product> Products { get; set; }
        public decimal Discount { get; set; }
    }
