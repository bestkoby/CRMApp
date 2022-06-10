using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Antra.CRMApp.Core.Model
{
    public class ProductRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SupplierId is required")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "CategoryId is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "QuantityPerUnit is required")]
        public int QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "UnitPrice is required")]
        public int UnitPrice { get; set; }

        [Required(ErrorMessage = "UnitInStock is required")]
        public int UnitInStock { get; set; }

        [Required(ErrorMessage = "UnitOnOrder  is required")]
        public int UnitOnOrder { get; set; }

        [Required(ErrorMessage = "ReorderLevel is required")]
        public int ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }
    }
}
