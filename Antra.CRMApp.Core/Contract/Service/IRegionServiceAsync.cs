using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IRegionServiceAsync
    {
        Task<IEnumerable<RegionModel>> GetAllAsync();

        Task<int> AddRegionAsync(RegionModel employee);

        Task<RegionModel> GetByIdAsync(int id);

        Task<RegionModel> GetRegionForEditAsync(int id);

        Task<int> UpdateRegionAsync(RegionModel employee);

        Task<int> DeleteRegionAsync(int id);
    }
}
