using System;
using System.Collections.Generic;
using System.Text;

namespace PrismMasterDetail.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public int salary { get; set; }
        public Address address { get; set; }
        public List<Product>products { get; set; }
    }
}
