﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.Base;
using WiredBrainCoffee.DataProvider;
using WiredBrainCoffee.Model;

namespace WiredBrainCoffee.ViewModel
{
    public class MainViewModel : Observable
    {
        private ICustomerDataProvider _customerDataProvider;   
        private Customer _selectedCustomer;
        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            Customers = new ObservableCollection<Customer>();
        }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set 
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsCustomerSelected));
                }
            }
        }

        public bool IsCustomerSelected => SelectedCustomer != null;

        public ObservableCollection<Customer> Customers { get; }
        public async Task LoadAsync()
        {
            Customers.Clear();
            var customers = await _customerDataProvider.LoadCustomersAsync();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }
        public async Task SaveAsync()
        {
            await _customerDataProvider.SaveCustomersAsync(Customers);
        }

        public void AddCustomer()
        {
            //var messageDialog = new MessageDialog("Customer added");
            //await messageDialog.ShowAsync();
            var customer = new Customer { FirstName = "New" };
            Customers.Add(customer);
           SelectedCustomer = customer;
        }

        public void DeleteCustomer()
        {
            var customer = SelectedCustomer;
            if (customer != null)
            {
                Customers.Remove(customer);
                SelectedCustomer = null;
            }
        }

    }
}
