using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using PrismMasterDetail.Services;
using PrismMasterDetail.Models;
using Prism.Navigation;

namespace PrismMasterDetail.ViewModels
{
    public class MasterPageViewModel : BindableBase
    {
        private ICustomerService _service;
        private INavigationService _navService;

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            private set { SetProperty(ref _customers, value); }
        }

        public DelegateCommand<object> ItemTappedCommand { get; private set; }
        

        private void OnItemTappedCommand(object obj)
        {
            var customer = obj as Customer;
            if (customer != null)
            {
                _service.CurrentCustomer = customer;
                _navService.NavigateAsync("PrismDetailPage");
            }
        }
        public MasterPageViewModel(ICustomerService service, INavigationService navService)
        {
            _service = service;
            _navService = navService;
            Customers = new ObservableCollection<Customer>();
            var listOfCustomers = _service.GetCustomers();
            foreach (var customer in listOfCustomers)
                Customers.Add(customer);

            if (_service.CurrentCustomer == null)
                _service.CurrentCustomer = Customers[0];

            ItemTappedCommand = new DelegateCommand<object>(OnItemTappedCommand);
        }
    }
}
