using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Model;
namespace Antra.CRMApp.Core.Contract.Service
{
    public interface ISupplierServiceAsync
    {
        Task<IEnumerable<SupplierModel>> GetAllAsync();

        Task<int> AddSupplierAsync(SupplierModel employee);

        Task<SupplierModel> GetByIdAsync(int id);

        Task<SupplierModel> GetSupplierForEditAsync(int id);

        Task<int> UpdateSupplierAsync(SupplierModel employee);

        Task<int> DeleteSupplierAsync(int id);
    }
}
