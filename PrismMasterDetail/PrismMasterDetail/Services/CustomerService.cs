using PrismMasterDetail.Models;
using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using PrismMasterDetail.Services;

namespace PrismMasterDetail.Services
{
    public class CustomerService : BindableBase, ICustomerService
    {
        private List<Customer> _allCustomers = new List<Customer>();
        private List<Address> _allAddresses = new List<Address>();
        private List<Product> _allProducts = new List<Product>();

        private Customer _currentCustomer;
        public Customer CurrentCustomer
        {
            get { return _currentCustomer; }
            set { SetProperty(ref _currentCustomer, value); }
        }

        public CustomerService()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo((this.GetType())).Assembly;
            Stream stream = assembly.GetManifestResourceStream("PrismMasterDetail.Data.MOCK_DATA_CUSTOMER.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var rootObject = JsonConvert.DeserializeObject<List<Customer>>(json);
                _allCustomers.AddRange(rootObject);
            }

            stream = assembly.GetManifestResourceStream("PrismMasterDetail.Data.MOCK_DATA_ADDRESS.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var rootObject = JsonConvert.DeserializeObject<List<Address>>(json);
                _allAddresses.AddRange(rootObject);
            }

            for (int i = 0; i < _allCustomers.Count; i++)
            {
                _allCustomers[i].address = _allAddresses[i];
            }

            stream = assembly.GetManifestResourceStream("PrismMasterDetail.Data.MOCK_DATA_PRODUCT.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var rootObject = JsonConvert.DeserializeObject<List<Product>>(json);
                _allProducts.AddRange(rootObject);
            }

            for (int i = 0; i < _allCustomers.Count; i++)
            {
                var productList = _allProducts.Where(p => p.customer_id == _allCustomers[i].id).OrderBy(p => p.order_date).ToList();
                _allCustomers[i].products = productList;
            }
        }

        public Customer GetCurrentCustomer()
        {
            return CurrentCustomer;
        }

        public List<Customer> GetCustomers()
        {
            return _allCustomers;
        }

        public void SetCurrentCustomer(Customer customer)
        {
            CurrentCustomer = customer;
        }
    }
}
