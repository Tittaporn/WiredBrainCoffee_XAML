using System.Collections.Generic;
using System.Threading.Tasks;
using WiredBrainCoffee.Model;

namespace WiredBrainCoffee.DataProvider
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>> LoadCustomersAsync();
        Task SaveCustomersAsync(IEnumerable<Customer> customers);
    }
}