﻿using System.ComponentModel.DataAnnotations;

namespace Company.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required!!")]
        public string Name { get; set; }

        [Range(25, 60, ErrorMessage = "Age must be between 25 and 60")]
        public int? Age { get; set; }

        [RegularExpression(@"[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{4,10}$", ErrorMessage = "Address must be like 123-street-City-Country")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salary is Required!!")]
        public double Salary { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
