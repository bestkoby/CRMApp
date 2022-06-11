using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;

        public CustomerServiceAsync(ICustomerRepositoryAsync _customer )
        {
            customerRepositoryAsync = _customer;
        }
        public async Task<int> AddCustomerAsync(CustomerRequestModel customer)
        {
            Customer c  = new Customer();
            c.Id = customer.Id;
            c.Title = customer.Title;
            c.Name = customer.Name;
            c.Address = customer.Address;
            c.Phone = customer.Phone;
            c.City = customer.City;
            c.Country = customer.Country;
            c.RegionId = customer.RegionId;
            c.PostalCode = customer.PostalCode;
            return await customerRepositoryAsync.InsertAsync(c);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            return await customerRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllAsync()
        {
            var collection = await customerRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<CustomerResponseModel> result = new List<CustomerResponseModel>();
                foreach (var item in collection)
                {
                    CustomerResponseModel model = new CustomerResponseModel();
                    model.Id = item.Id;
                    model.Phone = item.Phone; 
                    model.Title = item.Title; 
                    model.Address = item.Address;
                    model.City = item.City;
                    model.Name = item.Name;
                    model.Country = item.Country;
                    model.PostalCode = item.PostalCode;
                    model.RegionId = item.RegionId;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CustomerResponseModel> GetByIdAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerResponseModel model = new CustomerResponseModel();
                model.Id = item.Id;
                model.Phone = item.Phone;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.Name = item.Name;
                model.Country = item.Country;
                model.PostalCode = item.PostalCode;
                model.RegionId = item.RegionId;
                return model;
            }
            return null;
        }

        public async Task<CustomerRequestModel> GetCustomerForEditAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerRequestModel model = new CustomerRequestModel();
                model.Id = item.Id;
                model.Phone = item.Phone;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.Name = item.Name;
                model.Country = item.Country;
                model.PostalCode = item.PostalCode;
                model.RegionId = item.RegionId;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCustomerAsync(CustomerRequestModel item)
        {
            Customer model = new Customer();
            model.Id = item.Id;
            model.Phone = item.Phone;
            model.Title = item.Title;
            model.Address = item.Address;
            model.City = item.City;
            model.Name = item.Name;
            model.Country = item.Country;
            model.PostalCode = item.PostalCode;
            model.RegionId = item.RegionId;
            return await customerRepositoryAsync.UpdateAsync(model);
        }
    }
}
