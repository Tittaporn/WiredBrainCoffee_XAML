using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using WiredBrainCoffee.Model;
// Ctrol + . ==> Import or Autodelete

namespace WiredBrainCoffee.Controls
{
    [ContentProperty(Name = nameof(Customer))]
    public sealed partial class CustomerDetailControl : UserControl
    {
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register("Customer", typeof(Customer), typeof(CustomerDetailControl), new PropertyMetadata(null));

        public CustomerDetailControl()
        {
            this.InitializeComponent();
        }

        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }
    }
}

/* Before using biding in Chapter 9
        //  private Customer _customer;
        // Using a DependencyProperty as the backing store for Customer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register("Customer", typeof(Customer), typeof(CustomerDetailControl), new PropertyMetadata(null, CustomerChangedCallback));

        public CustomerDetailControl()
        {
            this.InitializeComponent();
        }

        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }


        private static void CustomerChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomerDetailControl customerDetailControl)
            {
                var customer = e.NewValue as Customer;
                customerDetailControl.txtFirstName.Text = customer?.FirstName ?? "";
                customerDetailControl.txtLastName.Text = customer?.LastName ?? "";
                customerDetailControl.chkIsDeveloper.IsChecked = customer?.IsDeveloper;
            }
        }

 
        public Customer Customer
         {
             get { return _customer; }
             set 
             { 
                 _customer = value;
                 txtFirstName.Text = _customer?.FirstName ?? "";
                 txtLastName.Text = _customer?.LastName ?? "";
                 chkIsDeveloper.IsChecked = _customer?.IsDeveloper;
             }
         }
     
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCustomer();
        }

        private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            UpdateCustomer();
        }

        private void UpdateCustomer()
        {
            // var customer = customerListView.SelectedItem as Customer;
            if (Customer != null)
            {
                Customer.FirstName = txtFirstName.Text;
                Customer.LastName = txtLastName.Text;
                Customer.IsDeveloper = chkIsDeveloper.IsChecked.GetValueOrDefault();
            }
        }
    }
}
   */