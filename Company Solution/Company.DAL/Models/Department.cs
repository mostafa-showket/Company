using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is Required!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }

        [DisplayName("Date Of Creation")]
        public DateTime DateOfCreation { get; set; }
    }
}
