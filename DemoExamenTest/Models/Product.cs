using System;
using System.Collections.Generic;

namespace DemoExamenTest.Models;
    public class Product
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public Partner Partner { get; set; }
        public int PartnerId { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public int ProductInfoId { get; set; }
    }