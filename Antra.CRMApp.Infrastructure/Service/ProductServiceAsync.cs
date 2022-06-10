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
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync _productRepositoryAsync;

        public ProductServiceAsync(IProductRepositoryAsync _product)
        {
            _productRepositoryAsync = _product;
        }
        public async Task<int> AddProductAsync(ProductRequestModel item)
        {
            Product p = new Product();
            p.Id = item.Id;
            p.Name = item.Name;
            p.SupplierId = item.SupplierId;
            p.CategoryId = item.CategoryId;
            p.QuantityPerUnit = item.QuantityPerUnit;
            p.UnitPrice = item.UnitPrice;
            p.UnitInStock = item.UnitInStock;
            p.UnitOnOrder = item.UnitOnOrder;
            p.ReorderLevel = item.ReorderLevel;
            p.Discontinued = item.Discontinued;
            return await _productRepositoryAsync.InsertAsync(p);
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            return await _productRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            var collection = await _productRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<ProductResponseModel> result = new List<ProductResponseModel>();
                foreach (var item in collection)
                {
                    ProductResponseModel model = new ProductResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.SupplierId = item.SupplierId;
                    model.CategoryId = item.CategoryId;
                    model.QuantityPerUnit = item.QuantityPerUnit;
                    model.UnitPrice = item.UnitPrice;
                    model.UnitInStock = item.UnitInStock;
                    model.UnitOnOrder = item.UnitOnOrder;
                    model.ReorderLevel = item.ReorderLevel;
                    model.Discontinued = item.Discontinued;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<ProductResponseModel> GetByIdAsync(int id)
        {
            var item = await _productRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ProductResponseModel p = new ProductResponseModel();
                p.Id = item.Id;
                p.Name = item.Name;
                p.SupplierId = item.SupplierId;
                p.CategoryId = item.CategoryId;
                p.QuantityPerUnit = item.QuantityPerUnit;
                p.UnitPrice = item.UnitPrice;
                p.UnitInStock = item.UnitInStock;
                p.UnitOnOrder = item.UnitOnOrder;
                p.ReorderLevel = item.ReorderLevel;
                p.Discontinued = item.Discontinued;
                return p;
            }
            return null;
        }

        public async Task<ProductRequestModel> GetProductForEditAsync(int id)
        {
            var item = await _productRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ProductRequestModel p = new ProductRequestModel();
                p.Id = item.Id;
                p.Name = item.Name;
                p.SupplierId = item.SupplierId;
                p.CategoryId = item.CategoryId;
                p.QuantityPerUnit = item.QuantityPerUnit;
                p.UnitPrice = item.UnitPrice;
                p.UnitInStock = item.UnitInStock;
                p.UnitOnOrder = item.UnitOnOrder;
                p.ReorderLevel = item.ReorderLevel;
                p.Discontinued = item.Discontinued;
                return p;
            }
            return null;
        }

        public async Task<int> UpdateProductAsync(ProductRequestModel item)
        {
            Product p = new Product();
            p.Id = item.Id;
            p.Name = item.Name;
            p.SupplierId = item.SupplierId;
            p.CategoryId = item.CategoryId;
            p.QuantityPerUnit = item.QuantityPerUnit;
            p.UnitPrice = item.UnitPrice;
            p.UnitInStock = item.UnitInStock;
            p.UnitOnOrder = item.UnitOnOrder;
            p.ReorderLevel = item.ReorderLevel;
            p.Discontinued = item.Discontinued;
            return await _productRepositoryAsync.UpdateAsync(p);
        }
    }
}
