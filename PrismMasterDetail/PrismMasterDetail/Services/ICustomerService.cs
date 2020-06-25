using PrismMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismMasterDetail.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();

        Customer CurrentCustomer { get; set; }
    }
}
