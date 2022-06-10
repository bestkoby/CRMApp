using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Model
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
         
        public string Name { get; set; }
         
        public int SupplierId { get; set; }
         
        public int CategoryId { get; set; }
         
        public int QuantityPerUnit { get; set; }
         
        public int UnitPrice { get; set; }
         
        public int UnitInStock { get; set; }
         
        public int UnitOnOrder { get; set; }
         
        public int ReorderLevel { get; set; }
         
        public bool Discontinued { get; set; }
    }
}
