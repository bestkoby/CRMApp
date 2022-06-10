using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IShipperServiceAsync
    {
        Task<IEnumerable<ShipperResponseModel>> GetAllAsync();

        Task<int> AddShipperAsync(ShipperRequestModel employee);

        Task<ShipperResponseModel> GetByIdAsync(int id);

        Task<ShipperRequestModel> GetShipperForEditAsync(int id);

        Task<int> UpdateShipperAsync(ShipperRequestModel employee);

        Task<int> DeleteShipperAsync(int id);
    }
}
