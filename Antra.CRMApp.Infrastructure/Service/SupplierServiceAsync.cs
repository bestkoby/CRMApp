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
    public class SupplierServiceAsync : ISupplierServiceAsync
    {
        private readonly ISupplierRepositoryAsync _supplierRepositoryAsync;

        public SupplierServiceAsync(ISupplierRepositoryAsync _s)
        {
            _supplierRepositoryAsync = _s;
        }
        public async  Task<int> AddSupplierAsync(SupplierModel item)
        {
            Supplier s = new Supplier();
            s.Id = item.Id;
            s.CompanyName = item.CompanyName;
            s.ContactName = item.ContactName;
            s.ContactTitle = item.ContactTitle;
            s.Address = item.Address;
            s.Phone = item.Phone;
            s.City = item.City;
            s.Country = item.Country;
            s.RegionId = item.RegionId;
            s.PostalCode = item.PostalCode;
            return await _supplierRepositoryAsync.InsertAsync(s);
        }

        public async Task<int> DeleteSupplierAsync(int id)
        {
            return await _supplierRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<SupplierModel>> GetAllAsync()
        {
            var collection = await _supplierRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<SupplierModel> result = new List<SupplierModel>();
                foreach (var item in collection)
                {
                    SupplierModel s = new SupplierModel();
                    s.Id = item.Id;
                    s.CompanyName = item.CompanyName;
                    s.ContactName = item.ContactName;
                    s.ContactTitle = item.ContactTitle;
                    s.Address = item.Address;
                    s.Phone = item.Phone;
                    s.City = item.City;
                    s.Country = item.Country;
                    s.RegionId = item.RegionId;
                    s.PostalCode = item.PostalCode;
                    result.Add(s);
                }
                return result;
            }
            return null;
        }

        public async Task<SupplierModel> GetByIdAsync(int id)
        {
            var item = await _supplierRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                SupplierModel s= new SupplierModel();
                s.Id = item.Id;
                s.CompanyName = item.CompanyName;
                s.ContactName = item.ContactName;
                s.ContactTitle = item.ContactTitle;
                s.Address = item.Address;
                s.Phone = item.Phone;
                s.City = item.City;
                s.Country = item.Country;
                s.RegionId = item.RegionId;
                s.PostalCode = item.PostalCode;
                return s;
            }
            return null;
        }

        public async Task<SupplierModel> GetSupplierForEditAsync(int id)
        {
            var item = await _supplierRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                SupplierModel s = new SupplierModel();
                s.Id = item.Id;
                s.CompanyName = item.CompanyName;
                s.ContactName = item.ContactName;
                s.ContactTitle = item.ContactTitle;
                s.Address = item.Address;
                s.Phone = item.Phone;
                s.City = item.City;
                s.Country = item.Country;
                s.RegionId = item.RegionId;
                s.PostalCode = item.PostalCode;
                return s;
            }
            return null;
        }

        public async Task<int> UpdateSupplierAsync(SupplierModel item)
        {
            Supplier s = new Supplier();
            s.Id = item.Id;
            s.CompanyName = item.CompanyName;
            s.ContactName = item.ContactName;
            s.ContactTitle = item.ContactTitle;
            s.Address = item.Address;
            s.Phone = item.Phone;
            s.City = item.City;
            s.Country = item.Country;
            s.RegionId = item.RegionId;
            s.PostalCode = item.PostalCode;
            return await _supplierRepositoryAsync.UpdateAsync(s);
        }
    }
}
