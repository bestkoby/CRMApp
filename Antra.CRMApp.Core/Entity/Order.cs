using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Antra.CRMApp.Core.Entity
{
    public class Order
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "CustomerID is required")] 
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "EmployeeID is required")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "OrderDate is required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "RequiredDate is required")]
        public DateTime RequiredDate { get; set; }

        [Required(ErrorMessage = "ShippedDate is required")]
        public DateTime ShippedDate { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string ShipName { get; set; } 

        [Required(ErrorMessage = "ShipAddress is required")]
        [Column(TypeName = "varchar(50)")]
        public string ShipAddress { get; set; }

        [Required(ErrorMessage = "ShipCity is required")]
        [Column(TypeName = "varchar(50)")]
        public string ShipCity { get; set; }

        [Required(ErrorMessage = "ShipRegion is required")]
        public int ShipRegion  { get; set; }

        [Required(ErrorMessage = "ShipPostalCode is required")]
        [Column(TypeName = "varchar(50)")]
        public string ShipPostalCode { get; set; }

        [Required(ErrorMessage = "ShipCountry is required")]
        [Column(TypeName = "varchar(50)")]
        public string ShipCountry { get; set; } 

    }
}
