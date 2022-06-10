using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class RegionServiceAsync : IRegionServiceAsync
    {
        private readonly IRegionRepositoryAsync regionRepositoryAsync;
        public RegionServiceAsync(IRegionRepositoryAsync repo)
        {
            regionRepositoryAsync = repo;
        }
        public async Task<int> AddRegionAsync(RegionModel model)
        {
            Region region = new Region();
            region.Name = model.Name;
            return await regionRepositoryAsync.InsertAsync(region);
        }

        public Task<int> DeleteRegionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RegionModel>> GetAllAsync()
        {
            var collection = await regionRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<RegionModel> regionModels = new List<RegionModel>();
                foreach (var item in collection)
                {
                    RegionModel model = new RegionModel();
                    model.Name = item.Name;
                    model.Id = item.Id;
                    regionModels.Add(model);
                }
                return regionModels;
            }
            return null;
        }

        public Task<RegionModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RegionModel> GetRegionForEditAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRegionAsync(RegionModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
