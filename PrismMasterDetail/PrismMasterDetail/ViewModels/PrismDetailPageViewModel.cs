using Prism.Commands;
using Prism.Mvvm;
using PrismMasterDetail.Models;
using PrismMasterDetail.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismMasterDetail.ViewModels
{
    public class PrismDetailPageViewModel : BindableBase
    {
        ICustomerService _service;

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set { SetProperty(ref _customer, value); }
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private int _salary;
        public int Salary
        {
            get { return _salary; }
            set { SetProperty(ref _salary, value); }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }

        private string _postalcode;
        public string Postalcode
        {
            get { return _postalcode; }
            set { SetProperty(ref _postalcode, value); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }

        private List<Product> products;
        public List<Product> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }
        public PrismDetailPageViewModel(ICustomerService service)
        {
            _service = service;
            if (_service.CurrentCustomer != null)
            {
                Customer = _service.CurrentCustomer;
                ID = Customer.id;
                Firstname = Customer.first_name;
                Lastname = Customer.last_name;
                Gender = Customer.gender;
                Email = Customer.email;
                Salary = Customer.salary;
                Country = Customer.address.country;
                Postalcode = Customer.address.postal_code;
                City = Customer.address.city;
                Street = Customer.address.street;
                Products = Customer.products;
            }
            
        }

       
    }
}
