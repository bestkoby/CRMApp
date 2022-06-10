using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Model
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
         
        public string FullName { get; set; }  

        public string Title { get; set; }
         
        public string TitleOfCourtesy { get; set; }
         
        public DateTime BirthDate { get; set; }
         
        public DateTime HireDate { get; set; } 

        public string Address { get; set; } 

        public string City { get; set; }
         
        //public int RegionId { get; set; } 

        public string PostalCode { get; set; }
         
        public string Country { get; set; }
         
        public string Phone { get; set; }
         
        //public string ReportsTo { get; set; }
         
        public string PhotoPath { get; set; }
    }
}
