using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Model
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }
         
        public string Name { get; set; }
         
        public string Title { get; set; }
         
        public string Address { get; set; }
         
        public string City { get; set; }
         
        public int RegionId { get; set; }
         
        public string PostalCode { get; set; }
         
        public string Country { get; set; }
         
        public string Phone { get; set; }
    }
}
