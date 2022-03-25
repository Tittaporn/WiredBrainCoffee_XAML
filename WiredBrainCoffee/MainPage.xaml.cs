using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WiredBrainCoffee.Controls;
using WiredBrainCoffee.DataProvider;
using WiredBrainCoffee.Model;
using WiredBrainCoffee.ViewModel;

namespace WiredBrainCoffee
{
    public sealed partial class MainPage : Page
    {
     //   private CustomerDataProvider _customerDataProvider;

        public MainViewModel ViewModel { get; }

        public MainPage()
        {
           
            this.InitializeComponent();
            ViewModel = new MainViewModel(new CustomerDataProvider());
            DataContext = ViewModel;
            this.Loaded += MainPage_Loaded;
            App.Current.Suspending += App_Suspending;
            // _customerDataProvider = new CustomerDataProvider();
            RequestedTheme = App.Current.RequestedTheme == ApplicationTheme.Dark
                   ? ElementTheme.Dark
                   : ElementTheme.Light;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            /* Before Biding in Chapter 9
             customerListView.Items.Clear();
             var customers = await _customerDataProvider.LoadCustomersAsync();
             foreach (var customer in customers)
             {
                 customerListView.Items.Add(customer);
             }
            */
            await ViewModel.LoadAsync();
        }

        private async void App_Suspending(object sender, SuspendingEventArgs e)
        {
            /* Before Biding in Chapter 9
          var deferral = e.SuspendingOperation.GetDeferral();
          await _customerDataProvider.SaveCustomersAsync(
              customerListView.Items.OfType<Customer>());
          deferral.Complete(); // To close application when async done
               */
            await ViewModel.SaveAsync();
        }

      private void ButtonMove_Click(object sender, RoutedEventArgs e)
      {
          // int column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
          int column = Grid.GetColumn(customerListGrid);
          int newColumn = column == 0 ? 2 : 0;
          // customerListGrid.SetValue(Grid.ColumnProperty, newColumn);
          Grid.SetColumn(customerListGrid, newColumn);
          moveSymbol.Symbol = newColumn == 0 ? Symbol.Forward : Symbol.Back;
      }       
        private void ButtonToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = RequestedTheme == ElementTheme.Dark
                ? ElementTheme.Light
                : ElementTheme.Dark;
        }
    }
}

/* Use this code below before chapter 9, binding to your data
    private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
{
    //var messageDialog = new MessageDialog("Customer added");
    //await messageDialog.ShowAsync();
    var customer = new Customer { FirstName = "New" };
    customerListView.Items.Add(customer);
    customerListView.SelectedItem = customer;
}

private void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
{
    var customer = customerListView.SelectedItem as Customer;
    if (customer != null)
    {
        customerListView.Items.Remove(customer);
    }
}

private void CustomerListView_SeletionChanged(object sender, SelectionChangedEventArgs e)
{
    var customer = customerListView.SelectedItem as Customer;
    customerDetailControl.Customer = customer;
    // Before Create Customer Detail File --> Use this code below
    // txtFirstName.Text = customer?.FirstName ?? "";
    // txtLastName.Text = customer?.LastName ?? "";
    // chkIsDeveloper.IsChecked = customer?.IsDeveloper;
}
*/
