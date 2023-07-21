using System.ComponentModel.DataAnnotations;

namespace Assignment02.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department code is Reuired")]

        public string Code { get; set; }
        [Required(ErrorMessage = "Department name is Reuired")]
        [MaxLength(3, ErrorMessage = "Minlenght is 3")]
        public string Name { get; set; }
    }
}
