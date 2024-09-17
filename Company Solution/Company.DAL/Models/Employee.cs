using System.ComponentModel.DataAnnotations;

namespace Company.DAL.Models
{
    public class Employee : BaseEntity
    {
        public int? Age { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public int? WorkForId { get; set; } // FK
        public Department? WorkFor { get; set; } // Navigational Property
    }
}
