using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface ICategoryServiceAsync
    {
        Task<IEnumerable<CategoryResponseModel>> GetAllAsync();

        Task<int> AddCategoryAsync(CategoryRequestModel employee);

        Task<CategoryResponseModel> GetByIdAsync(int id);

        Task<CategoryRequestModel> GetCategoryForEditAsync(int id);

        Task<int> UpdateCategoryAsync(CategoryRequestModel employee);

        Task<int> DeleteCategoryAsync(int id);

    }
}
