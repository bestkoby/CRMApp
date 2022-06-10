using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Antra.CRMApp.Core.Model
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required(ErrorMessage = "TitleOfCourtesy is required")]
        [Column(TypeName = "varchar(50)")]
        public string TitleOfCourtesy { get; set; }

        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "HireDate is required")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }

        [Required(ErrorMessage = "RegionId is required")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "PostalCode is required")]
        [Column(TypeName = "varchar(50)")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "ReportsTo is required")]
        [Column(TypeName = "varchar(20)")]
        public string ReportsTo { get; set; }

        [Required(ErrorMessage = "PhotoPath is required")]
        [Column(TypeName = "varchar(100)")]
        public string PhotoPath { get; set; }
    }
}
