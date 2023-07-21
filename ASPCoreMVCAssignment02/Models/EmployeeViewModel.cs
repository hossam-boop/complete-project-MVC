using DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace Assignment02.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(5)]

        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        //[DataType(DataType.Date)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public int DepartmentId { get; set; }
        public  DepartmentViewModel Department { get; set; }
    }
}
