using System.ComponentModel.DataAnnotations;

namespace Company.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required!!")]
        public string Name { get; set; }
    }
}
