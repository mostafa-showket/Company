using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.DAL.Models
{
    public class Department : BaseEntity
    {
        [Required(ErrorMessage = "Code is Required!")]
        public string Code { get; set; }

        [DisplayName("Date Of Creation")]
        public DateTime DateOfCreation { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
