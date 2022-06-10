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
    public class ShipperServiceAsync : IShipperServiceAsync
    {
        private readonly IShipperRepositoryAsync _shipperRepositoryAsync;

        public ShipperServiceAsync(IShipperRepositoryAsync _s)
        {
            _shipperRepositoryAsync = _s;
        }

        public async Task<int> AddShipperAsync(ShipperRequestModel item)
        {
            Shipper s = new Shipper();
            s.Id = item.Id;
            s.Name = item.Name;
            s.Phone = item.Phone;
            return await _shipperRepositoryAsync.InsertAsync(s);

        }

        public async Task<int> DeleteShipperAsync(int id)
        {
            return await _shipperRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetAllAsync()
        {
            var collection = await _shipperRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<ShipperResponseModel> result = new List<ShipperResponseModel>();
                foreach (var item in collection)
                {
                    ShipperResponseModel s = new ShipperResponseModel();
                    s.Id = item.Id;
                    s.Name = item.Name;
                    s.Phone = item.Phone;
                    result.Add(s);
                }
                return result;
            }
            return null;
        }

        public async Task<ShipperResponseModel> GetByIdAsync(int id)
        {
            var item = await _shipperRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ShipperResponseModel s = new ShipperResponseModel();
                s.Id = item.Id;
                s.Name = item.Name;
                s.Phone = item.Phone;
                return s;
            }
            return null;
        }

        public async Task<ShipperRequestModel> GetShipperForEditAsync(int id)
        {
            var item = await _shipperRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ShipperRequestModel s = new ShipperRequestModel();
                s.Id = item.Id;
                s.Name = item.Name;
                s.Phone = item.Phone;
                return s;
            }
            return null;
        }

        public async Task<int> UpdateShipperAsync(ShipperRequestModel item)
        {
            Shipper s = new Shipper();
            s.Id = item.Id;
            s.Name = item.Name;
            s.Phone = item.Phone;
            return await _shipperRepositoryAsync.UpdateAsync(s);
        }
    }
}
