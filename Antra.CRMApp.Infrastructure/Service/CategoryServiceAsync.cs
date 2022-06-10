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
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync _categoryRepositoryAsync;

        public CategoryServiceAsync(ICategoryRepositoryAsync _category )
        {
            _categoryRepositoryAsync = _category;
        }

        public async Task<int> AddCategoryAsync(CategoryRequestModel item)
        {
            Category c = new Category();
            c.Id = item.Id;
            c.Name = item.Name;
            c.Description = item.Description;
            return await _categoryRepositoryAsync.InsertAsync(c);
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await _categoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAllAsync()
        {
            var collection = await _categoryRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<CategoryResponseModel> result = new List<CategoryResponseModel>();
                foreach (var item in collection)
                {
                    CategoryResponseModel model = new CategoryResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Description = item.Description; 
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CategoryResponseModel> GetByIdAsync(int id)
        {
            var item = await _categoryRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CategoryResponseModel c = new CategoryResponseModel();
                c.Id = item.Id;
                c.Name = item.Name;
                c.Description = item.Description;
                return c;
            }
            return null;
        }

        public async Task<CategoryRequestModel> GetCategoryForEditAsync(int id)
        {
            var item = await _categoryRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CategoryRequestModel c = new CategoryRequestModel();
                c.Id = item.Id;
                c.Name = item.Name;
                c.Description = item.Description;
                return c;
            }
            return null;
        }

        public async Task<int> UpdateCategoryAsync(CategoryRequestModel item)
        {
            Category c  = new Category();
            c.Id = item.Id;
            c.Name = item.Name;
            c.Description = item.Description;
            return await _categoryRepositoryAsync.UpdateAsync(c);
        }
    } 
}
