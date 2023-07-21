using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Department
    {
        public Department()
        {
            DateOfCreation = DateTime.Now;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Department code is Reuired")]

        public string Code { get; set; }
        [Required(ErrorMessage = "Department name is Reuired")]
        [MaxLength(3,ErrorMessage ="Minlenght is 3")]
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public virtual ICollection<Employee> Employees { get;} = new List<Employee>();

    }
}
