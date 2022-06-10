using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface ICustomerServiceAsync
    {
        Task<IEnumerable<CustomerResponseModel>> GetAllAsync();

        Task<int> AddCustomerAsync(CustomerRequestModel employee);

        Task<CustomerResponseModel> GetByIdAsync(int id);

        Task<CustomerRequestModel> GetCustomerForEditAsync(int id);

        Task<int> UpdateCustomerAsync(CustomerRequestModel employee);

        Task<int> DeleteCustomerAsync(int id);

    }
}
