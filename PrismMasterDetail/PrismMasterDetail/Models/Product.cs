using System;
using System.Collections.Generic;
using System.Text;

namespace PrismMasterDetail.Models
{
    public class Product
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public string order_date { get; set; }
        public string product { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
    }
}
