using System;
using System.Collections.Generic;
using System.Text;

namespace PrismMasterDetail.Models
{
    public class Address
    {
        public int employee_id { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string street { get; set; }
        public string city { get; set; }
    }
}
